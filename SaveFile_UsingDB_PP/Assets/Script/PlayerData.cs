using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家資料
/// 要轉回Json
/// </summary>
public class PlayerData 
{
    public int coin;
    public float posX;
    public float posY;
    public Quaternion angle;
    public float time;



    //建構子
    //會在此類別成為物件實執行一次，處理初始化
    /// <summary>
    /// 建立玩家資料
    /// </summary>
    /// <param name="coin">金幣</param>
    /// <param name="posX">座標X</param>
    /// <param name="posY">座標Y</param>
    public PlayerData(int coin, float posX, float posY) 
    {
        this.coin = coin;
        this.posX = posX;
        this.posY = posY;
    }

    /// <summary>
    /// 多載1
    /// </summary>
    /// <param name="coin"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="angle">角度</param>
    /// <param name="time">時間</param>
    public PlayerData(int coin, float posX, float posY,Quaternion angle,float time)
    {
        this.coin = coin;
        this.posX = posX;
        this.posY = posY;
        this.angle = angle;
        this.time = time;


    }


}
