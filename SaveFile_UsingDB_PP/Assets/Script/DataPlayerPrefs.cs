using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ce1206
{
    /// <summary>
    /// ����x�s
    /// PP�Ҧ��G�ϥ�Unity API Player Prefs
    /// </summary>
    public class DataPlayerPrefs : DataSaveLoadBase
    {

        [Header("PP�M���x�s��� key")]
        public string keyGold = "�����ƶq";
        public string keyPl_Posx = "���aX�b";
        public string keyPl_Posy = "���aY�b";

        public override void SaveData()
        {
            base.SaveData();
            PlayerPrefs.SetInt(keyGold, glodenManager.goldCnt);
            PlayerPrefs.SetFloat(keyPl_Posx, playerPos.position.x);
            PlayerPrefs.SetFloat(keyPl_Posy, playerPos.position.y);
        }
        public override void LoadData()
        {
            base.LoadData();

            #region Ū�����
            Vector3 posLoad =Vector3.zero;
            glodenManager.goldCnt = PlayerPrefs.GetInt(keyGold);
            posLoad.x = PlayerPrefs.GetInt(keyPl_Posx);
            posLoad.y = PlayerPrefs.GetFloat(keyPl_Posy);
            #endregion

            #region ��s����
            glodenManager.UpdateData();
            playerPos.position = posLoad;
            #endregion
        }
    }


}