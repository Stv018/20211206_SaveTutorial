using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Ce1206
{
    /// <summary>
    /// �ϥθ�Ʈw�s�����
    /// </summary>
    ///
    public class DataDB : DataSaveLoadBase
    {
 
        private string urlsave = "https://ce777.000webhostapp.com/Save.php";
        private WWWForm form;

        public override void SaveData()
        {
            base.SaveData();

            form = new WWWForm();       //�s�W ��檫��
            form.AddField("coin", glodenManager.goldCnt);  //���K�[�������P��
            form.AddField("posX", playerPos.position.x.ToString());  //���K�[�������P��
            form.AddField("posY", playerPos.position.y.ToString());  //���K�[�������P��
            
            StartCoroutine(StartSaveData());               //�Ұ��x�s���
        }

        public override void LoadData()
        {
            base.LoadData();
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


    }
}