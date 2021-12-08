using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Ce1206
{
    /// <summary>
    /// 使用資料庫存取資料
    /// </summary>
    ///
    public class DataDB : DataSaveLoadBase
    {
 
        private string urlsave = "https://ce777.000webhostapp.com/save.php";
        private WWWForm form;

        public override void SaveData()
        {
            base.SaveData();

            form = new WWWForm();       //新增 表單物件
            form.AddField("coin", glodenManager.goldCnt);  //表單添加金幣欄位與值
            StartCoroutine(StartSaveData());               //啟動儲存資料
        }

        public override void LoadData()
        {
            base.LoadData();
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


    }
}