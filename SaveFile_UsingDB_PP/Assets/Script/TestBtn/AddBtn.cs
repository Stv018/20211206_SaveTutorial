using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBtn : MonoBehaviour
{
    [Header("�s�ɫ��s")]
    public Button[] btn;
    public Event[]  useBtn;


    [Header("")]
    public Text[] index;

    [Header("�����Ʀr")]
    public Text[] SwapPage;  //3-10

    public AddBtn()
    {

        

    }

    private void Awake()
    {


        //���o�C�Ӥ���
        //�N�C�ӫ��s�[�J�ƥ� �ë��w�ӭ�(index)�ƥ�
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
