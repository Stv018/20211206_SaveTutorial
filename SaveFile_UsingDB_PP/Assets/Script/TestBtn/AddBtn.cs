using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBtn : MonoBehaviour
{
    [Header("存檔按鈕")]
    public Button[] btn;
    public Event[]  useBtn;


    [Header("")]
    public Text[] index;

    [Header("頁面數字")]
    public Text[] SwapPage;  //3-10

    public AddBtn()
    {

        

    }

    private void Awake()
    {


        //取得每個元件
        //將每個按鈕加入事件 並指定該值(index)事件
        for (int i = 0; i < btn.Length - 1; i++)
            {
                btn[i] = GetComponent<Button>();
                btn[i].onClick.AddListener(() => Btnclick(i));
            }
    }

    void Update()
    {
            
    }

    private void Btnclick(int id) 
    {
        print("i" + id + "\n");
        return;
    }



}
