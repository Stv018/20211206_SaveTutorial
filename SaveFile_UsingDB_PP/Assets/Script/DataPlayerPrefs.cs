using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ce1206
{
    /// <summary>
    /// 資料儲存
    /// PP模式：使用Unity API Player Prefs
    /// </summary>
    public class DataPlayerPrefs : DataSaveLoadBase
    {

        [Header("PP專用儲存資料 key")]
        public string keyGold = "金幣數量";
        public string keyPl_Posx = "玩家X軸";
        public string keyPl_Posy = "玩家Y軸";

        public override void SaveData()
        {
            base.SaveData();
            PlayerPrefs.SetInt(keyGold, goldenManager.goldCnt);
            PlayerPrefs.SetFloat(keyPl_Posx, playerPos.position.x);
            PlayerPrefs.SetFloat(keyPl_Posy, playerPos.position.y);
        }
        public override void LoadData()
        {
            base.LoadData();

            #region 讀取資料
            Vector3 posLoad =Vector3.zero;
            goldenManager.goldCnt = PlayerPrefs.GetInt(keyGold);
            posLoad.x = PlayerPrefs.GetInt(keyPl_Posx);
            posLoad.y = PlayerPrefs.GetFloat(keyPl_Posy);
            #endregion

            #region 更新物件
            goldenManager.UpdateData();
            playerPos.position = posLoad;
            #endregion
        }
    }


}