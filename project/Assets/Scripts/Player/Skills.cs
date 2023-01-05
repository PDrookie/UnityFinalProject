using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skills
{
    //���S�����o�ޯ�
    private bool Active;

    //���S���bCD��
    private bool InCD;

    //���S���b��
    private bool Using;



    //����ɶ���CD
    public float CD;
    public float ContinueTime;

    public float SpeedMul;
    public int ATKMul;
    public int HealNum;
    

    public abstract void Effect();
    public abstract void Terminate();
    public void SetCD(float f)
    {
        CD = f;
    }

    public bool active
    {
        get
        {
            return Active;
        }
        set
        {
            Active = value;
        }
    }

    public bool _Using
    {
        get
        {
            return Using;
        }
        set
        {
            Using = value;
        }
    }
    public bool inCD
    {
        get
        {
            return InCD;
        }
        set
        {
            InCD = value;
        }
    }
}