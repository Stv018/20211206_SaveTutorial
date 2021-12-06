using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ce1206
{
    /// <summary>
    /// 採金礦管理器
    /// </summary>
    public class GlodenManager : MonoBehaviour
    {
        #region 欄位，公開
        [Header("採礦半徑"),Range(0,10)]
        public float radius = 3.5f;
        [Header("採礦按鈕")]
        public KeyCode keyGold = KeyCode.E;
        [Header("GZ顏色調整")]
        public Color clr_radius;

        [Header("目標Layer")]
        public LayerMask layerTarget;
        [Header("金幣數量")]
        public Text Txtcoin;
        #endregion

        /// <summary>
        /// 數金礦用
        /// </summary>
        #region 欄位：私人
        private int goldcnt;
        #endregion

        #region 屬性：私人
        /// <summary>
        /// 按下採礦按鍵
        /// </summary>
        private bool InputGold{ get => Input.GetKeyDown(keyGold); }

        /// <summary>
        /// 目標是否在Gz半徑
        /// </summary>
        private bool TargetInRadius { get => Physics2D.OverlapCircle(transform.position, radius, layerTarget); }
        
        #endregion

        #region 事件
        /// <summary>
        /// 劃出GZ，偵測用
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = clr_radius;
            //Gizmos.color = new Color(0.2f,0.5f,0.1f,0.7f);
            Gizmos.DrawSphere(transform.position, radius);
        }
        #endregion

        #region 方法：私人
        /// <summary>
        /// 數錢啦
        /// </summary>
        private void GetGold() 
        {
            if (InputGold && TargetInRadius)
            {
                goldcnt++;
                Txtcoin.text = "金幣數量：" + goldcnt;
            }
        }


        #endregion


        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            GetGold();
        }
    }
}