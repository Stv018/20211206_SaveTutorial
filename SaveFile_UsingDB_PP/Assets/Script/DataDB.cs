using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

namespace Ce1206
{
    /// <summary>
    /// 使用資料庫存取資料
    /// </summary>
    ///
    public class DataDB : DataSaveLoadBase
    {
 
        private string urlsave = "https://ce777.000webhostapp.com/save.php";
        private string urlload = "https://ce777.000webhostapp.com/load.php";
        private WWWForm form;
        /// <summary>
        /// 傳輸結束
        /// </summary>
        private string result;

       // private GlodenManager Gloden;
        public override void SaveData()
        {
            base.SaveData();

            form = new WWWForm();       //新增 表單物件goldenManager.goldCnt
            form.AddField("coin", goldenManager.goldCnt);  //表單添加金幣欄位與值
            form.AddField("posX", playerPos.position.x.ToString());  //表單添加金幣欄位與值
            form.AddField("posY", playerPos.position.y.ToString());  //表單添加金幣欄位與值
            
            StartCoroutine(StartSaveData());               //啟動儲存資料
        }

        public override void LoadData()
        {
            base.LoadData();

            form = new WWWForm();
            form.AddField("search", "coin");
            StartCoroutine(StartLinkData(urlload,"金幣"));

            form = new WWWForm();
            form.AddField("search", "posX");
            StartCoroutine(StartLinkData(urlload, "座標X"));

            form = new WWWForm();
            form.AddField("search", "posY");
            StartCoroutine(StartLinkData(urlload, "座標Y"));
        }

        private IEnumerator StartSaveData() 
        {
           /* WWW www = new WWW(urlsave, form);   //透過網路傳輸傳遞資料到 save.php
            yield return www;                   //等待傳輸
           */
            using (UnityWebRequest www = UnityWebRequest.Post(urlsave, form)) 
            {
                yield return www.SendWebRequest();
                print("傳輸狀態:" + www.isDone);
            }
        
        }

        private IEnumerator StartLinkData(string url,string updateItem = "")
        {
            /* WWW www = new WWW(urlsave, form);   //透過網路傳輸傳遞資料到 save.php
             yield return www;                   //等待傳輸
            */
            using (UnityWebRequest www = UnityWebRequest.Post(url, form))
            {
                yield return www.SendWebRequest();          //等待傳輸
                print("傳輸狀態:" + www.isDone);
                result = www.downloadHandler.text;
                print("傳輸結果:" + result);                //傳輸結果
            }

            if (updateItem == "金幣")
            {
                goldenManager.goldCnt = Convert.ToInt32(result);
                goldenManager.UpdateData();


            }

            if (updateItem == "座標X")
            {
                float x = Convert.ToSingle(result);
                playerPos.position = new Vector3(x,playerPos.position.y,0);
                goldenManager.UpdateData();


            }

            if (updateItem == "座標Y")
            {
                float y = Convert.ToSingle(result);
                playerPos.position = new Vector3( playerPos.position.x,y, 0);
                goldenManager.UpdateData();


            }


        }

    }
}