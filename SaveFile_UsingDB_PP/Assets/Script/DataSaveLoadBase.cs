using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ce1206
{
    /// <summary>
    /// 資料載入與儲存 通用基底
    /// </summary>
    public class DataSaveLoadBase : MonoBehaviour
    {

        [Header("要儲存的資料")]
        public GlodenManager goldenManager;
        public Transform playerPos;

        #region 方法 公開並允許複寫

        /// <summary>
        /// 儲存資料
        /// </summary>
        /// 

        public virtual void SaveData()
        {


        }

        /// <summary>
        /// 載入資料
        /// </summary>
        public virtual void LoadData()
        {


        }

        #endregion

    }
}