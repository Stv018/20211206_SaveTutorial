using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UWR�ޥ�
using UnityEngine.Networking;


namespace Ce1206
{

    /// <summary>
    /// �ϥ�GAS�s�����
    /// Google Application Script
    /// </summary>
    public class DataGas : DataSaveLoadBase
    {
        /// <summary>
        /// GAS�s��  �Φr���x�s��K�ե�
        /// </summary>
        private string gasurl =
            "https://script.google.com/macros/s/AKfycbwEcd-qBPSrDEoPS7TaxrEc46SguSPNFmjLzSayUgQDrGuJ2q9NUZj_V_0tEA51DuX4/exec";
                  private WWWForm form;
        private string result;
        

        public override void LoadData()
        {
            #region Ū�����
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 1);
           /* StartCoroutine(LoadGASData("����"));

            form.AddField("row", 2);
            form.AddField("col", 2);
            StartCoroutine(LoadGASData("�y��X"));

            form.AddField("row", 2);
            form.AddField("col", 3);
            StartCoroutine(LoadGASData("�y��Y"));*/

           /*// base.LoadData();
            StartCoroutine(LoadGASData());*/
            #endregion
        }

        public override void SaveData()
        {
            base.SaveData();
            form = new WWWForm();
            StartCoroutine(LinkGAS("�g�J"));  //���~
            #region �x�s���
           
            form.AddField("coin", glodenManager.goldCnt);
            form.AddField("PosX", playerPos.position.x.ToString());
            form.AddField("PosY", playerPos.position.y.ToString());

            #endregion

        }


        private IEnumerator LoadGASData(string update) 
        {
            yield return StartCoroutine(LinkGAS("Ū��"));

            #region ��s����
            if (update == "����")
            {
                // print("�����ƶq" +result);
                glodenManager.goldCnt = Convert.ToInt32(result);
                glodenManager.UpdateData();
               // StartCoroutine(LoadGASData());
            }
            if (update == "�y�� X")
            {
                float x = Convert.ToSingle(result);
                playerPos.position = new Vector3(x, playerPos.position.y, 0);
            }
            if (update == "�y�� Y")
            {
                float y = Convert.ToSingle(result);
                playerPos.position = new Vector3(playerPos.position.x,y, 0);
                // print("�����ƶq" +result);
                glodenManager.goldCnt = Convert.ToInt32(result);
                glodenManager.UpdateData();
                StartCoroutine(LoadGASData(update));
            }

            #endregion

        }

        /// <summary>
        /// �s����GAS
        /// </summary>
        /// <param name="loadOrSave">�g�J�BŪ��</param>
        /// <returns></returns>
        private IEnumerator LinkGAS(string loadOrSave)
        {
            //WWWForm form = new WWWForm();
            form.AddField("method", loadOrSave);

            //POST ������n����� ��w�����
            //GET�����n����� �p�@�ιD��W��
            using (UnityWebRequest www = UnityWebRequest.Post(gasurl, form))
            {
                yield return www.SendWebRequest();  //���ݶǿ駹��
                result = www.downloadHandler.text;
                // print(www.downloadHandler.text);  //�S����
                print( result);
                // print("��ƶǿ駹���G" +www.isDone);
            }
        }
    }
}