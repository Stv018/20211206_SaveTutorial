using UnityEngine;

namespace Ce1206
{
    /// <summary>
    /// 2D ���ⱱ�
    /// </summary>
    public class Char_2D : MonoBehaviour
    {
        #region ���A���}
        [Header("����"), Range(0, 10)]
        public float movespeed = 3.5f;
        [Header("�ʵe�Ѽ�")]
        public string para_AniRun= "Run";
        #endregion

        #region ���A�p�H
        private Rigidbody2D rig;
        private Animator ani;
        #endregion

        #region �ݩʡG�p�H
        public float InputHorizontal { get => Input.GetAxis("Horizontal"); }

        #endregion


        #region �ƥ�
        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }
        #endregion
        void FixedUpdate()
        {
            Move();
           
        }

        #region ��k�G�p�H
        /// <summary>
        /// ����
        /// </summary>
        private void Move()
        {
            rig.velocity = new Vector2(movespeed * InputHorizontal, rig.velocity.y);
        }

        /// <summary>
        /// ½��
        /// </summary>
        private void Flip() 
        {
            if (Mathf.Abs(InputHorizontal) < 0.1f) return;  //��������� <0.1 �~Ĳ(�Ӥp�O)���B�z
            float yAngle = InputHorizontal > 0 ? 0 : 180;   //������ >0 ����0,�_�h=180 
            transform.eulerAngles = new Vector3(0, yAngle, 0); //��s�کԨ���,�۷��flipX
        }

        /// <summary>
        /// ��s�ʧ@ InputHorizontal !=0 +-1=>true 
        /// </summary>
        private void UpdateAnimation() 
        {

            ani.SetBool(para_AniRun, InputHorizontal != 0);
        }

        #endregion

        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {
            Flip();
            UpdateAnimation();
        }
    }
}