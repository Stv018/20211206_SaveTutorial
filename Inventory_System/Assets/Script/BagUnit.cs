using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 介面上要變化的的UI
/// </summary>
public class BagUnit : MonoBehaviour
{
    //物品圖片\
    public Image m_Icon = null;
    //數量文字
    public Text m_CountText = null;
    //裝備文字
    public Text m_EquipText = null;

    //引用ItemData 當資料庫撈
    public ItemData m_TempData = null;

    /// <summary>
    /// 刷新並顯示
    /// </summary>
    /// <param name="itemData"></param>
    public void Refresh(ItemData itemData)
    {
        if (itemData == null) 
        {
            //初始化空格
            m_Icon.sprite = null;
            m_CountText.text = "";
            m_EquipText.text = "";
            return;
        }
        //暫存資料
        m_TempData = itemData;
        m_Icon.sprite = itemData.m_Icon;
        m_CountText.text = itemData.m_Count.ToString();
        m_EquipText.text = "";
    }

    
    public void OnEquip(bool equip)
    {
        //將圖形變成 equip
        m_TempData.m_Equip = equip;
        RefreshEquip();
    }

    /// <summary>
    /// 切換顯示 裝備中
    /// </summary>
    public void RefreshEquip() 
    {
        //點擊後，將Text = UI.TEXT
        if (m_TempData.m_Equip)
            m_EquipText.text = "裝備中";
        else
            m_EquipText.text = "";

    }





}


