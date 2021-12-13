using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背包基礎定義
/// m_Icon  道具圖片
/// m_Count 道具數量
/// </summary>
public class ItemData
{
    //道具圖片
    public Sprite m_Icon = null;
    //數量
    public int m_Count = 0;
    //ID
    public int m_ItemTag = 0;
    //可否裝備
    public bool m_Equip = false;

}