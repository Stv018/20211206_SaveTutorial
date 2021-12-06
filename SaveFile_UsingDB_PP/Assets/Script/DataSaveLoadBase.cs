using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ce1206
{
    /// <summary>
    /// ��Ƹ��J�P�x�s �q�ΰ�
    /// </summary>
    public class DataSaveLoadBase : MonoBehaviour
    {

        [Header("�n�x�s�����")]
        public GlodenManager glodenManager;
        public Transform playerPos;

        #region ��k ���}�ä��\�Ƽg

        /// <summary>
        /// �x�s���
        /// </summary>
        /// 

        public virtual void SaveData()
        {


        }

        /// <summary>
        /// ���J���
        /// </summary>
        public virtual void LoadData()
        {


        }

        #endregion

    }
}