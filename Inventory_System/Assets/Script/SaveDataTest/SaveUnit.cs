using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

#region 資料庫內容
//SaveItem
//等級
/*public int char_Lv; V
//金幣 
public int coin; V
//ID
    public int inttag; 

    //檔案是否存在
    public bool fileIsExist;
 
 */
#endregion

/// <summary>
/// 每一格的存檔UI內容
/// </summary>
public class SaveUnit : MonoBehaviour
{
    //物品圖片
    public Image Save_Icon = null;
    //等級文字
    public Text Lvtxt = null;
    //金幣文字
    public Text Cointxt = null;
  

    //引用SaveItem 當資料庫用
    public SaveItem savedb;

    /// <summary>
    /// 每次開始確認資料,在讀取
    /// </summary>
    /// <param name="saveItem"></param>
    public void Refresh(SaveItem saveItem)
    {
        //if(!tag) 如果沒檔案
        savedb = saveItem;
        Lvtxt.text = saveItem.char_Lv.ToString();
        Cointxt.text = saveItem.coin.ToString();
        Save_Icon.sprite = saveItem.Save_Sp;

       // LoadData();
        return;
        
    }

    /// <summary>
    /// 存檔轉換 將UI上的丟回資料庫
    /// </summary>
    public void SaveData() 
    {
        savedb.char_Lv = Convert.ToInt32(Lvtxt.text);
        savedb.coin = Convert.ToInt32(Cointxt.text);
        savedb.Save_Sp = Save_Icon.sprite;

    }

    /// <summary>
    /// 讀取檔案(1)=>暫存資料
    /// </summary>
    public void LoadData() 
    {
       Lvtxt.text= savedb.char_Lv.ToString();
        Cointxt.text = savedb.coin.ToString();
        Save_Icon.sprite = savedb.Save_Sp;



    }

}
