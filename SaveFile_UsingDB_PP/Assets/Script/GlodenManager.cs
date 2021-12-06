using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ce1206
{
    /// <summary>
    /// �Ī��q�޲z��
    /// </summary>
    public class GlodenManager : MonoBehaviour
    {
        #region ���A���}
        [Header("���q�b�|"),Range(0,10)]
        public float radius = 3.5f;
        [Header("���q���s")]
        public KeyCode keyGold = KeyCode.E;
        [Header("GZ�C��վ�")]
        public Color clr_radius;

        [Header("�ؼ�Layer")]
        public LayerMask layerTarget;
        [Header("�����ƶq")]
        public Text Txtcoin;

        [HideInInspector] //�ݩʭ��O�W����
        public int goldCnt;
        #endregion

        /// <summary>
        /// �ƪ��q��
        /// </summary>
        #region ���G�p�H

        #endregion

        #region �ݩʡG�p�H
        /// <summary>
        /// ���U���q����
        /// </summary>
        private bool InputGold{ get => Input.GetKeyDown(keyGold); }

        /// <summary>
        /// �ؼЬO�_�bGz�b�|
        /// </summary>
        private bool TargetInRadius { get => Physics2D.OverlapCircle(transform.position, radius, layerTarget); }
        
        #endregion

        #region �ƥ�
        /// <summary>
        /// ���XGZ�A������
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = clr_radius;
            //Gizmos.color = new Color(0.2f,0.5f,0.1f,0.7f);
            Gizmos.DrawSphere(transform.position, radius);
        }
        #endregion

        #region ��k�G�p�H
        /// <summary>
        /// �ƿ���
        /// </summary>
        private void GetGold() 
        {
            if (InputGold && TargetInRadius)
            {
                goldCnt++;
                Txtcoin.text = "�����ƶq�G" + goldCnt;
            }
        }

        #endregion

        /// <summary>
        /// �ΥHŪ����
        /// </summary>
        public void UpdateData() 
        {
            Txtcoin.text = "�����ƶq�G" + goldCnt;

        }

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