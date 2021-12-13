using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

namespace Ce1206
{
    /// <summary>
    /// �ϥθ�Ʈw�s�����
    /// </summary>
    ///
    public class DataDB : DataSaveLoadBase
    {
 
        private string urlsave = "https://ce777.000webhostapp.com/save.php";
        private string urlload = "https://ce777.000webhostapp.com/load.php";
        private WWWForm form;
        /// <summary>
        /// �ǿ鵲��
        /// </summary>
        private string result;

       // private GlodenManager Gloden;
        public override void SaveData()
        {
            base.SaveData();

            form = new WWWForm();       //�s�W ��檫��goldenManager.goldCnt
            form.AddField("coin", goldenManager.goldCnt);  //���K�[�������P��
            form.AddField("posX", playerPos.position.x.ToString());  //���K�[�������P��
            form.AddField("posY", playerPos.position.y.ToString());  //���K�[�������P��
            
            StartCoroutine(StartSaveData());               //�Ұ��x�s���
        }

        public override void LoadData()
        {
            base.LoadData();

            form = new WWWForm();
            form.AddField("search", "coin");
            StartCoroutine(StartLinkData(urlload,"����"));

            form = new WWWForm();
            form.AddField("search", "posX");
            StartCoroutine(StartLinkData(urlload, "�y��X"));

            form = new WWWForm();
            form.AddField("search", "posY");
            StartCoroutine(StartLinkData(urlload, "�y��Y"));
        }

        private IEnumerator StartSaveData() 
        {
           /* WWW www = new WWW(urlsave, form);   //�z�L�����ǿ�ǻ���ƨ� save.php
            yield return www;                   //���ݶǿ�
           */
            using (UnityWebRequest www = UnityWebRequest.Post(urlsave, form)) 
            {
                yield return www.SendWebRequest();
                print("�ǿ骬�A:" + www.isDone);
            }
        
        }

        private IEnumerator StartLinkData(string url,string updateItem = "")
        {
            /* WWW www = new WWW(urlsave, form);   //�z�L�����ǿ�ǻ���ƨ� save.php
             yield return www;                   //���ݶǿ�
            */
            using (UnityWebRequest www = UnityWebRequest.Post(url, form))
            {
                yield return www.SendWebRequest();          //���ݶǿ�
                print("�ǿ骬�A:" + www.isDone);
                result = www.downloadHandler.text;
                print("�ǿ鵲�G:" + result);                //�ǿ鵲�G
            }

            if (updateItem == "����")
            {
                goldenManager.goldCnt = Convert.ToInt32(result);
                goldenManager.UpdateData();


            }

            if (updateItem == "�y��X")
            {
                float x = Convert.ToSingle(result);
                playerPos.position = new Vector3(x,playerPos.position.y,0);
                goldenManager.UpdateData();


            }

            if (updateItem == "�y��Y")
            {
                float y = Convert.ToSingle(result);
                playerPos.position = new Vector3( playerPos.position.x,y, 0);
                goldenManager.UpdateData();


            }


        }

    }
}