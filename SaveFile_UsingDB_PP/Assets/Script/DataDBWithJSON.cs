using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;


namespace Ce1206
{
    /// <summary>
    /// 透過資料庫存取資料 資料使用JSON存取
    /// </summary>
    public class DataDBWithJSON : DataSaveLoadBase
    {
        private string urlsave = "https://ce777.000webhostapp.com/savejson.php";
        private string urlload = "https://ce777.000webhostapp.com/loadjson.php";
        private WWWForm form;
        /// <summary>
        /// 傳輸結束
        /// </summary>
        private string result;

        public override void SaveData()
        {
            base.SaveData();

            //新增玩家資料並儲存金幣 POSX POSY
            //PlayerData data = new PlayerData(goldenManager.goldCnt, playerPos.position.x, playerPos.position.y);

            PlayerData data = new PlayerData(goldenManager.goldCnt, playerPos.position.x, playerPos.position.y,playerPos.rotation,Time.timeSinceLevelLoad);

            string dataJSON = JsonUtility.ToJson(data);
            print("JSON資料:<color=yellow>" + dataJSON + "</color>");

            //將JSON資料添加到表單內 欄位名稱為[json
            form = new WWWForm();
            form.AddField("json", dataJSON);
            StartCoroutine(StartLinkData(urlsave));
        }

        public override void LoadData()
        {
            base.LoadData();

            form = new WWWForm();
            form.AddField("json", "json");
            StartCoroutine(StartLinkData(urlload, true));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">要溝通的PHP</param>
        /// <param name="load">是否為載入模式</param>
        /// <returns></returns>
        private IEnumerator StartLinkData(string url,bool load=false)
        {
            using (UnityWebRequest www = UnityWebRequest.Post(url, form))
            {
                yield return www.SendWebRequest();
                print("傳輸狀態:" + www.isDone);
                result = www.downloadHandler.text;
                //print("傳輸結果:" + result);                //傳輸結果

            }

            if (load) 
            {
                PlayerData data = JsonUtility.FromJson<PlayerData>(result);
                print("取得金幣:<color=yellow>" + data.coin + "</color>");

                goldenManager.goldCnt = data.coin;
                goldenManager.UpdateData();

                float x = data.posX;
                float y = data.posY;
                playerPos.position = new Vector3(x, y, 0);
                playerPos.rotation = data.angle;
                print("上次遊玩時間:<color=pink>" + data.time + "</color>" );

            }
        }
    }
}