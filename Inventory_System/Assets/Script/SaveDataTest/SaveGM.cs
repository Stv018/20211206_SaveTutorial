using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGM : MonoBehaviour
{
    //�s�ɪ���l  //��檫��
    public SaveUnit m_Cloneunit;
    //�s�ɪ���m GP
    public Transform Save_Node;
    //�Ȧs�I���Ϥ�
    public Sprite Prt_BGImg;

    //�Ȧs�Ҧ��s�ɮ�l
   // public List<SaveUnit> sv_unit = new List<SaveUnit>();
    
    //�Ȧs�I�]����M���
    public List<SaveItem> m_TotalSaveSpData = new List<SaveItem>();

    //�O�_���I���s��
    public bool clickSave;
    //�O�_���I��Ū��
    public bool clickLoad;

    //public SaveUnit SU;

    //�ɮ׬O�_�s�b
    public bool Is_Exist;


    /// <summary>
    /// �N�Ҧ��ɮש��UI��l�W�A�H�K���aŪ��
    /// </summary>
    public void postFile()
    {
        //���ɮפW��UI����Ū�J
        

    }

    /// <summary>
    /// ���ͦ�10��s�ɦ�m
    /// Create All Empty Grid On ManyPage
    /// </summary>
    public void createSaveId(/*int n*/)
    {
        for (int i = 0; i < 10;i++)
        {
            SaveItem svid = new SaveItem();
            svid.Save_Sp = Prt_BGImg;
            svid.char_Lv = 10;
            svid.coin = 555;
            
            //id.Save_Sp = 

            //�bContnet�W �ͦ�
            m_TotalSaveSpData.Add(svid);
            //�ͦ��å�� Grid Griup����l��
            SaveUnit unit = Instantiate<SaveUnit>(m_Cloneunit, Save_Node);

            //�N�ȥ��UI�W
            unit.Refresh(m_TotalSaveSpData[i]);
        }
     /*   for (int i = 0; i < m_TotalSaveSpData.Count; i++)
        {
            
            //unit.Refresh(m_TotalSaveSpData[i]);
            //���ͦ�

        }*/
    }

    /// <summary>
    /// �ҰʹC���ɧ�����Ū�J
    /// </summary>
    private void Awake()
    {
        if (Is_Exist)
        {
            postFile();             //Post ALL File On UI
            createSaveId();         //Create All Empty Grid On ManyPage
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        createSaveId();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
