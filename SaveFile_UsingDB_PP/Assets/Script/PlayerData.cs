using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���a���
/// �n��^Json
/// </summary>
public class PlayerData 
{
    public int coin;
    public float posX;
    public float posY;
    public Quaternion angle;
    public float time;



    //�غc�l
    //�|�b�����O������������@���A�B�z��l��
    /// <summary>
    /// �إߪ��a���
    /// </summary>
    /// <param name="coin">����</param>
    /// <param name="posX">�y��X</param>
    /// <param name="posY">�y��Y</param>
    public PlayerData(int coin, float posX, float posY) 
    {
        this.coin = coin;
        this.posX = posX;
        this.posY = posY;
    }

    /// <summary>
    /// �h��1
    /// </summary>
    /// <param name="coin"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="angle">����</param>
    /// <param name="time">�ɶ�</param>
    public PlayerData(int coin, float posX, float posY,Quaternion angle,float time)
    {
        this.coin = coin;
        this.posX = posX;
        this.posY = posY;
        this.angle = angle;
        this.time = time;


    }


}
