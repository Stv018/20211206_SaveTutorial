using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGM : MonoBehaviour
{
    //存檔的格子  //單格物件
    public SaveUnit m_Cloneunit;
    //存檔的位置 GP
    public Transform Save_Node;
    //暫存背景圖片
    public Sprite Prt_BGImg;

    //暫存所有存檔格子
   // public List<SaveUnit> sv_unit = new List<SaveUnit>();
    
    //暫存背包物件清單用
    public List<SaveItem> m_TotalSaveSpData = new List<SaveItem>();

    //是否有點擊存檔
    public bool clickSave;
    //是否有點擊讀黨
    public bool clickLoad;

    //public SaveUnit SU;

    //檔案是否存在
    public bool Is_Exist;


    /// <summary>
    /// 將所有檔案放到UI格子上，以便玩家讀取
    /// </summary>
    public void postFile()
    {
        //抓檔案上的UI物件讀入
        

    }

    /// <summary>
    /// 先生成10格存檔位置
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

            //在Contnet上 生成
            m_TotalSaveSpData.Add(svid);
            //生成並丟到 Grid Griup的格子中
            SaveUnit unit = Instantiate<SaveUnit>(m_Cloneunit, Save_Node);

            //將值丟到UI上
            unit.Refresh(m_TotalSaveSpData[i]);
        }
     /*   for (int i = 0; i < m_TotalSaveSpData.Count; i++)
        {
            
            //unit.Refresh(m_TotalSaveSpData[i]);
            //單格生成

        }*/
    }

    /// <summary>
    /// 啟動遊戲時抓取資料讀入
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
