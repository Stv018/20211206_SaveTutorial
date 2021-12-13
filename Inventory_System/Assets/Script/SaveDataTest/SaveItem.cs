using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 預設通用資料型態
/// </summary>
public class SaveItem 
{
    //Saveindex
    //ID
    //public int inttag;
    //  //存檔圖片
    public Sprite Save_Sp;
    //等級
    public int char_Lv;
    //金幣 SaveItem
    public int coin;

    //檔案是否存在
    public bool fileIsExist=false;
  

    /*  //當前血量
      public int char_Hp;
      //當前eng
      public int char_eng;

      //已通關場景 
     public int Stage;
      //當前item 0=>med 1=>reel
      public int[] bagcnt;
      //skill Lv
      public int[] SkLvcnt;
      //屬性配點
      public int[] arrpoint;*/




}

public enum itemchar
{ 
    Lv,


} 


