using UnityEngine;
//USE GAS
using UnityEngine.Networking;
//��P�ϥ�
using System.Collections;
using System;

namespace Ce1206
{
    public class DataUseGas : DataSaveLoadBase
    {
        /// <summary>
        /// GAS�ɦW�s�� �ɦW��.exec
        /// </summary>

        private string gas = "https://script.google.com/macros/s/AKfycbxGKHJYUJ1xgrw572OHsUEyayFHEqrQdb35Xdef3jGG1EUvmIyfddlLiCvWVvPBDDyB/exec";
        private WWWForm form;
        private string result;
     

        public override void SaveData()
        {
            base.SaveData();
            #region �x�s���
            form = new WWWForm();
            form.AddField("coin", goldenManager.goldCnt);
           
            form.AddField("posX", playerPos.position.x.ToString());
            form.AddField("posY", playerPos.position.y.ToString());

            StartCoroutine(LinkGAS("�g�J"));

            #endregion
        }

        public override void LoadData()
        {
            base.LoadData();

            #region Ū�����
            //�C����s�ɮײM��
            form = new WWWForm();
            form.AddField("row" , 2);
            form.AddField("col" , 1);
            StartCoroutine(LoadGASData("����"));
            
            //�C����s�ɮײM��
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 2);
            StartCoroutine(LoadGASData("�y�� X"));

            //�C����s�ɮײM��
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 3);
            StartCoroutine(LoadGASData("�y�� Y"));
            #endregion 
        }

        private IEnumerator  LoadGASData(string update) 
        {
            yield return StartCoroutine(LinkGAS("Ū��"));

            #region ��s���� �קKŪ���{���]�ӧ� ���Ϳ��~
            //print("�����ƶq�G" + result);  //�줣��
            if (update == "����")
            {
                goldenManager.goldCnt =  Convert.ToInt32(result);
                goldenManager.UpdateData();
            }
            else if (update == "�y�� X")
            {
                float x = Convert.ToSingle(result);
                playerPos.position = new Vector3(x, playerPos.position.y , 0);
            }

            else if (update == "�y�� Y")
            {
                float y = Convert.ToSingle(result);
                playerPos.position = new Vector3(playerPos.position.x, y , 0);
            }
           /* form.AddField("row", 2);
            form.AddField("col", 2);
            StartCoroutine(LoadGASData("�y�� Y"));*/
            #endregion
        }



        /// <summary>
        /// �s����GAS
        /// </summary>
        /// <param name="loadOrSave">�g�JŪ��</param>
        /// <returns></returns>
        private IEnumerator LinkGAS(string loadOrSave) 
        {
            //��������
            //WWWForm form = new WWWForm();
            form.AddField("method", loadOrSave);

            // ���},�N�J���
            using (UnityWebRequest www = UnityWebRequest.Post(gas, form))
            {
                yield return www.SendWebRequest();
                //print(www.isDone);   //���ҬO�_���ǿ馨�\\(Unity�W)  ��=>true

                //���J�e�� 0~1 �i�H��Ū���i�ױ�
                //www.downloadProgress
                result = www.downloadHandler.text;
              //  print(result);   ///���� ���s��
            }


        }


    }

}