using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �����W�n�ܤƪ���UI
/// </summary>
public class BagUnit : MonoBehaviour
{
    //���~�Ϥ�\
    public Image m_Icon = null;
    //�ƶq��r
    public Text m_CountText = null;
    //�˳Ƥ�r
    public Text m_EquipText = null;

    //�ޥ�ItemData ���Ʈw��
    public ItemData m_TempData = null;

    /// <summary>
    /// ��s�����
    /// </summary>
    /// <param name="itemData"></param>
    public void Refresh(ItemData itemData)
    {
        if (itemData == null) 
        {
            //��l�ƪŮ�
            m_Icon.sprite = null;
            m_CountText.text = "";
            m_EquipText.text = "";
            return;
        }
        //�Ȧs���
        m_TempData = itemData;
        m_Icon.sprite = itemData.m_Icon;
        m_CountText.text = itemData.m_Count.ToString();
        m_EquipText.text = "";
    }

    
    public void OnEquip(bool equip)
    {
        //�N�ϧ��ܦ� equip
        m_TempData.m_Equip = equip;
        RefreshEquip();
    }

    /// <summary>
    /// ������� �˳Ƥ�
    /// </summary>
    public void RefreshEquip() 
    {
        //�I����A�NText = UI.TEXT
        if (m_TempData.m_Equip)
            m_EquipText.text = "�˳Ƥ�";
        else
            m_EquipText.text = "";

    }





}


