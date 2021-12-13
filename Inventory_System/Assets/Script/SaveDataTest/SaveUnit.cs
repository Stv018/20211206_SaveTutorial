using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

#region ��Ʈw���e
//SaveItem
//����
/*public int char_Lv; V
//���� 
public int coin; V
//ID
    public int inttag; 

    //�ɮ׬O�_�s�b
    public bool fileIsExist;
 
 */
#endregion

/// <summary>
/// �C�@�檺�s��UI���e
/// </summary>
public class SaveUnit : MonoBehaviour
{
    //���~�Ϥ�
    public Image Save_Icon = null;
    //���Ť�r
    public Text Lvtxt = null;
    //������r
    public Text Cointxt = null;
  

    //�ޥ�SaveItem ���Ʈw��
    public SaveItem savedb;

    /// <summary>
    /// �C���}�l�T�{���,�bŪ��
    /// </summary>
    /// <param name="saveItem"></param>
    public void Refresh(SaveItem saveItem)
    {
        //if(!tag) �p�G�S�ɮ�
        savedb = saveItem;
        Lvtxt.text = saveItem.char_Lv.ToString();
        Cointxt.text = saveItem.coin.ToString();
        Save_Icon.sprite = saveItem.Save_Sp;

       // LoadData();
        return;
        
    }

    /// <summary>
    /// �s���ഫ �NUI�W����^��Ʈw
    /// </summary>
    public void SaveData() 
    {
        savedb.char_Lv = Convert.ToInt32(Lvtxt.text);
        savedb.coin = Convert.ToInt32(Cointxt.text);
        savedb.Save_Sp = Save_Icon.sprite;

    }

    /// <summary>
    /// Ū���ɮ�(1)=>�Ȧs���
    /// </summary>
    public void LoadData() 
    {
       Lvtxt.text= savedb.char_Lv.ToString();
        Cointxt.text = savedb.coin.ToString();
        Save_Icon.sprite = savedb.Save_Sp;



    }

}
