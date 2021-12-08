using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UWR引用
using UnityEngine.Networking;


namespace Ce1206
{

    /// <summary>
    /// 使用GAS存取資料
    /// Google Application Script
    /// </summary>
    public class DataGas : DataSaveLoadBase
    {
        /// <summary>
        /// GAS連結  用字串儲存方便調用
        /// </summary>
        private string gasurl =
            "https://script.google.com/macros/s/AKfycbwEcd-qBPSrDEoPS7TaxrEc46SguSPNFmjLzSayUgQDrGuJ2q9NUZj_V_0tEA51DuX4/exec";
                  private WWWForm form;
        private string result;
        

        public override void LoadData()
        {
            #region 讀取資料
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 1);
           /* StartCoroutine(LoadGASData("金幣"));

            form.AddField("row", 2);
            form.AddField("col", 2);
            StartCoroutine(LoadGASData("座標X"));

            form.AddField("row", 2);
            form.AddField("col", 3);
            StartCoroutine(LoadGASData("座標Y"));*/

           /*// base.LoadData();
            StartCoroutine(LoadGASData());*/
            #endregion
        }

        public override void SaveData()
        {
            base.SaveData();
            form = new WWWForm();
            StartCoroutine(LinkGAS("寫入"));  //錯誤
            #region 儲存資料
           
            form.AddField("coin", glodenManager.goldCnt);
            form.AddField("PosX", playerPos.position.x.ToString());
            form.AddField("PosY", playerPos.position.y.ToString());

            #endregion

        }


        private IEnumerator LoadGASData(string update) 
        {
            yield return StartCoroutine(LinkGAS("讀取"));

            #region 更新物件
            if (update == "金幣")
            {
                // print("金幣數量" +result);
                glodenManager.goldCnt = Convert.ToInt32(result);
                glodenManager.UpdateData();
               // StartCoroutine(LoadGASData());
            }
            if (update == "座標 X")
            {
                float x = Convert.ToSingle(result);
                playerPos.position = new Vector3(x, playerPos.position.y, 0);
            }
            if (update == "座標 Y")
            {
                float y = Convert.ToSingle(result);
                playerPos.position = new Vector3(playerPos.position.x,y, 0);
                // print("金幣數量" +result);
                glodenManager.goldCnt = Convert.ToInt32(result);
                glodenManager.UpdateData();
                StartCoroutine(LoadGASData(update));
            }

            #endregion

        }

        /// <summary>
        /// 連結到GAS
        /// </summary>
        /// <param name="loadOrSave">寫入、讀取</param>
        /// <returns></returns>
        private IEnumerator LinkGAS(string loadOrSave)
        {
            //WWWForm form = new WWWForm();
            form.AddField("method", loadOrSave);

            //POST 比較重要的資料 資安比較高
            //GET不重要的資料 如共用道具名稱
            using (UnityWebRequest www = UnityWebRequest.Post(gasurl, form))
            {
                yield return www.SendWebRequest();  //等待傳輸完成
                result = www.downloadHandler.text;
                // print(www.downloadHandler.text);  //沒反應
                print( result);
                // print("資料傳輸完成：" +www.isDone);
            }
        }
    }
}