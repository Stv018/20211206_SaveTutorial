using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class BagManager : MonoBehaviour
{
    //��檫��
    public BagUnit m_cloneUnit = null;
    //GP����l
    public Transform m_BagNode = null;

    //�s��Ҧ��Ϥ�
    public Sprite[] m_TotalItemSp;

    //�Ȧs�I�]����M���
    public List<ItemData> m_TotalItemSpData = new List<ItemData>();

    //�x�s�A�I�]���Ҧ��ͦ����~
    public List<BagUnit> m_TotalItemBagUnit = new List<BagUnit>();

    /// <summary>
    /// ����Bool
    /// </summary>
    public bool m_isleft = true;

    /// <summary>
    /// �������� �P�k��˳Ʀ�m
    /// </summary>
    public BagUnit m_LeftUnit = null;
    public BagUnit m_RightUnit = null;



    /// <summary>
    /// ��ƪ�l�� (�M�ť��k��)
    /// </summary>
    private void Awake()
    {
        m_LeftUnit.Refresh(null);
        m_RightUnit.Refresh(null);
    }

    /// <summary>
    /// �ͦ�����ܪ��W
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            ItemData id = new ItemData();
            id.m_Count = 1;
            //�����h�ӹD��
            int r = Random.Range(0, m_TotalItemSp.Length);
            Sprite sp = m_TotalItemSp[r];

            id.m_Icon = sp;
            id.m_Count = 1;
            id.m_ItemTag = r;

            //�ͦ��C��D��
            m_TotalItemSpData.Add(id);
            //�Ƨ� l�洫  -1���洫
            //m_TotalItemSpData.Sort(SortItem);

        }

       for (int i = 0; i < m_TotalItemSpData.Count; i++)
        {
            //�ͦ��å�� Grid Griup����l��
            BagUnit unit = Instantiate<BagUnit>(m_cloneUnit, m_BagNode);
            unit.Refresh(m_TotalItemSpData[i]);
            
            m_TotalItemBagUnit.Add(unit);
        }
    }

    /// <summary>
    /// ��s�I�]���
    /// </summary>
    private void RefreshList()
    {

        for (int i = 0; i < m_TotalItemBagUnit.Count; i++)
        {
            m_TotalItemBagUnit[i].RefreshEquip();
        }

    }

    /// <summary>
    /// �Ƨ�
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int SortItem(object a, object b)
    {
        ItemData i1 = a as ItemData;
        ItemData i2 = b as ItemData;

        //�洫
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
    /// �I���ƥ� ����x�s���s�W
    /// </summary>
    public void OnclickUnit(BagUnit unit) 
    {

        unit.OnEquip(true);

        //T =>�˳Ƥ��AF=""
        //m_LeftUnit.Refresh(unit.m_TempData);

        //m_isleft �I����(�x�s)
        if (m_isleft)
        {
            if (m_LeftUnit.m_TempData != null) 
            {
                //�����˳�
                m_LeftUnit.OnEquip(false);
            }
            m_LeftUnit.Refresh(unit.m_TempData);
            
        }

        //m_isleft �I�k��(Ū��)
        else
        {
            //print(m_isleft);  //f
            if (m_RightUnit.m_TempData != null)
            {
                //�����˳�
                m_RightUnit.OnEquip(false);
                print("\n:�����˳Ʈ�"+m_isleft);
                
            }
            m_RightUnit.Refresh(unit.m_TempData);
            //print("\n��s�˳Ʈ�" + m_isleft);
        }

        //��s�˳�
        RefreshList();

    }



    public void OnclickLeft() 
    {
        m_isleft = true;

    }

    /// <summary>
    /// ���O�I�����=>�k��
    /// </summary>
    public void OnclickRight()
    {
        m_isleft = false;
    }


}


/*/// <summary>
/// �I�]�Ѽ�
/// </summary>
public class ItemData 
{ 



}*/
