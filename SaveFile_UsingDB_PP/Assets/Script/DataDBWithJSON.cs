using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;


namespace Ce1206
{
    /// <summary>
    /// �z�L��Ʈw�s����� ��ƨϥ�JSON�s��
    /// </summary>
    public class DataDBWithJSON : DataSaveLoadBase
    {
        private string urlsave = "https://ce777.000webhostapp.com/savejson.php";
        private string urlload = "https://ce777.000webhostapp.com/loadjson.php";
        private WWWForm form;
        /// <summary>
        /// �ǿ鵲��
        /// </summary>
        private string result;

        public override void SaveData()
        {
            base.SaveData();

            //�s�W���a��ƨ��x�s���� POSX POSY
            //PlayerData data = new PlayerData(goldenManager.goldCnt, playerPos.position.x, playerPos.position.y);

            PlayerData data = new PlayerData(goldenManager.goldCnt, playerPos.position.x, playerPos.position.y,playerPos.rotation,Time.timeSinceLevelLoad);

            string dataJSON = JsonUtility.ToJson(data);
            print("JSON���:<color=yellow>" + dataJSON + "</color>");

            //�NJSON��ƲK�[���椺 ���W�٬�[json
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
        /// <param name="url">�n���q��PHP</param>
        /// <param name="load">�O�_�����J�Ҧ�</param>
        /// <returns></returns>
        private IEnumerator StartLinkData(string url,bool load=false)
        {
            using (UnityWebRequest www = UnityWebRequest.Post(url, form))
            {
                yield return www.SendWebRequest();
                print("�ǿ骬�A:" + www.isDone);
                result = www.downloadHandler.text;
                //print("�ǿ鵲�G:" + result);                //�ǿ鵲�G
            }

            if (load) 
            {
                PlayerData data = JsonUtility.FromJson<PlayerData>(result);
                print("���o����:<color=yellow>" + data.coin + "</color>");

                goldenManager.goldCnt = data.coin;
                goldenManager.UpdateData();

                float x = data.posX;
                float y = data.posY;
                playerPos.position = new Vector3(x, y, 0);
                playerPos.rotation = data.angle;
                print("�W���C���ɶ�:<color=pink>" + data.time + "</color>" );

            }
        }
    }
}