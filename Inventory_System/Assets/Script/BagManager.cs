using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class BagManager : MonoBehaviour
{
    //單格物件
    public BagUnit m_cloneUnit = null;
    //GP的格子
    public Transform m_BagNode = null;

    //存放所有圖片
    public Sprite[] m_TotalItemSp;

    //暫存背包物件清單用
    public List<ItemData> m_TotalItemSpData = new List<ItemData>();

    //儲存，背包中所有生成物品
    public List<BagUnit> m_TotalItemBagUnit = new List<BagUnit>();

    /// <summary>
    /// 左手Bool
    /// </summary>
    public bool m_isleft = true;

    /// <summary>
    /// 模擬左手 與右手裝備位置
    /// </summary>
    public BagUnit m_LeftUnit = null;
    public BagUnit m_RightUnit = null;



    /// <summary>
    /// 資料初始化 (清空左右格)
    /// </summary>
    private void Awake()
    {
        m_LeftUnit.Refresh(null);
        m_RightUnit.Refresh(null);
    }

    /// <summary>
    /// 生成物件至表單上
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            ItemData id = new ItemData();
            id.m_Count = 1;
            //模擬多個道具
            int r = Random.Range(0, m_TotalItemSp.Length);
            Sprite sp = m_TotalItemSp[r];

            id.m_Icon = sp;
            id.m_Count = 1;
            id.m_ItemTag = r;

            //生成每格道具
            m_TotalItemSpData.Add(id);
            //排序 l交換  -1不交換
            //m_TotalItemSpData.Sort(SortItem);

        }

       for (int i = 0; i < m_TotalItemSpData.Count; i++)
        {
            //生成並丟到 Grid Griup的格子中
            BagUnit unit = Instantiate<BagUnit>(m_cloneUnit, m_BagNode);
            unit.Refresh(m_TotalItemSpData[i]);
            
            m_TotalItemBagUnit.Add(unit);
        }
    }

    /// <summary>
    /// 刷新背包資料
    /// </summary>
    private void RefreshList()
    {

        for (int i = 0; i < m_TotalItemBagUnit.Count; i++)
        {
            m_TotalItemBagUnit[i].RefreshEquip();
        }

    }

    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int SortItem(object a, object b)
    {
        ItemData i1 = a as ItemData;
        ItemData i2 = b as ItemData;

        //交換
        if (i1.m_ItemTag > i2.m_ItemTag)
        {
            return 1;

        }


        if (i1.m_ItemTag < i2.m_ItemTag)
        {
            return -1;
        }

        else //i1==i2
        {
            //cnt++;
            return 0;
        }


    }




    /// <summary>
    /// 點擊事件 丟到儲存按鈕上
    /// </summary>
    public void OnclickUnit(BagUnit unit) 
    {

        unit.OnEquip(true);

        //T =>裝備中，F=""
        //m_LeftUnit.Refresh(unit.m_TempData);

        //m_isleft 點左邊(儲存)
        if (m_isleft)
        {
            if (m_LeftUnit.m_TempData != null) 
            {
                //卸除裝備
                m_LeftUnit.OnEquip(false);
            }
            m_LeftUnit.Refresh(unit.m_TempData);
            
        }

        //m_isleft 點右邊(讀取)
        else
        {
            //print(m_isleft);  //f
            if (m_RightUnit.m_TempData != null)
            {
                //卸除裝備
                m_RightUnit.OnEquip(false);
                print("\n:卸除裝備時"+m_isleft);
                
            }
            m_RightUnit.Refresh(unit.m_TempData);
            //print("\n更新裝備時" + m_isleft);
        }

        //更新裝備
        RefreshList();

    }



    public void OnclickLeft() 
    {
        m_isleft = true;

    }

    /// <summary>
    /// 不是點左邊時=>右邊
    /// </summary>
    public void OnclickRight()
    {
        m_isleft = false;
    }


}


/*/// <summary>
/// 背包參數
/// </summary>
public class ItemData 
{ 



}*/
