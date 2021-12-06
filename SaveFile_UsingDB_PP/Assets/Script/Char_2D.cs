using UnityEngine;

namespace Ce1206
{
    /// <summary>
    /// 2D 角色控制器
    /// </summary>
    public class Char_2D : MonoBehaviour
    {
        #region 欄位，公開
        [Header("移動"), Range(0, 10)]
        public float movespeed = 3.5f;
        [Header("動畫參數")]
        public string para_AniRun= "Run";
        #endregion

        #region 欄位，私人
        private Rigidbody2D rig;
        private Animator ani;
        #endregion

        #region 屬性：私人
        public float InputHorizontal { get => Input.GetAxis("Horizontal"); }

        #endregion


        #region 事件
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

        #region 方法：私人
        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            rig.velocity = new Vector2(movespeed * InputHorizontal, rig.velocity.y);
        }

        /// <summary>
        /// 翻面
        /// </summary>
        private void Flip() 
        {
            if (Mathf.Abs(InputHorizontal) < 0.1f) return;  //水平絕對值 <0.1 誤觸(太小力)不處理
            float yAngle = InputHorizontal > 0 ? 0 : 180;   //水平直 >0 角度0,否則=180 
            transform.eulerAngles = new Vector3(0, yAngle, 0); //更新歐拉角度,相當於flipX
        }

        /// <summary>
        /// 更新動作 InputHorizontal !=0 +-1=>true 
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