using UnityEngine;
//USE GAS
using UnityEngine.Networking;
//協同使用
using System.Collections;
using System;

namespace Ce1206
{
    public class DataUseGas : DataSaveLoadBase
    {
        /// <summary>
        /// GAS檔名連結 檔名為.exec
        /// </summary>

        private string gas = "https://script.google.com/macros/s/AKfycbxGKHJYUJ1xgrw572OHsUEyayFHEqrQdb35Xdef3jGG1EUvmIyfddlLiCvWVvPBDDyB/exec";
        private WWWForm form;
        private string result;
     

        public override void SaveData()
        {
            base.SaveData();
            #region 儲存資料
            form = new WWWForm();
            form.AddField("coin", goldenManager.goldCnt);
           
            form.AddField("posX", playerPos.position.x.ToString());
            form.AddField("posY", playerPos.position.y.ToString());

            StartCoroutine(LinkGAS("寫入"));

            #endregion
        }

        public override void LoadData()
        {
            base.LoadData();

            #region 讀取資料
            //每次更新檔案清空
            form = new WWWForm();
            form.AddField("row" , 2);
            form.AddField("col" , 1);
            StartCoroutine(LoadGASData("金幣"));
            
            //每次更新檔案清空
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 2);
            StartCoroutine(LoadGASData("座標 X"));

            //每次更新檔案清空
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 3);
            StartCoroutine(LoadGASData("座標 Y"));
            #endregion 
        }

        private IEnumerator  LoadGASData(string update) 
        {
            yield return StartCoroutine(LinkGAS("讀取"));

            #region 更新物件 避免讀取程式跑太快 產生錯誤
            //print("金幣數量：" + result);  //抓不到
            if (update == "金幣")
            {
                goldenManager.goldCnt =  Convert.ToInt32(result);
                goldenManager.UpdateData();
            }
            else if (update == "座標 X")
            {
                float x = Convert.ToSingle(result);
                playerPos.position = new Vector3(x, playerPos.position.y , 0);
            }

            else if (update == "座標 Y")
            {
                float y = Convert.ToSingle(result);
                playerPos.position = new Vector3(playerPos.position.x, y , 0);
            }
           /* form.AddField("row", 2);
            form.AddField("col", 2);
            StartCoroutine(LoadGASData("座標 Y"));*/
            #endregion
        }



        /// <summary>
        /// 連結到GAS
        /// </summary>
        /// <param name="loadOrSave">寫入讀取</param>
        /// <returns></returns>
        private IEnumerator LinkGAS(string loadOrSave) 
        {
            //抓取表單資料
            //WWWForm form = new WWWForm();
            form.AddField("method", loadOrSave);

            // 網址,代入表單
            using (UnityWebRequest www = UnityWebRequest.Post(gas, form))
            {
                yield return www.SendWebRequest();
                //print(www.isDone);   //驗證是否有傳輸成功\(Unity上)  有=>true

                //載入畫面 0~1 可以做讀取進度條
                //www.downloadProgress
                result = www.downloadHandler.text;
              //  print(result);   ///爛表單 換新的
            }


        }


    }

}