using Assets.Script.���ܽӿ�;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour,MoveInterface
{
    //�ٶȱ���
    public int speed;

    //��ҵ�Ѫ��
    public int health_Value;

    //��ҵ���Ծ��
    public float jumping_Power;

    //��ҵ�����״̬
    public bool isLive;

    public GameObject up, down;

    public bool isgroud;

    //����ƶ�����
    public virtual void Move()
    {
        
    }

    public virtual void Start()
    {
    }
    public virtual void Update()
    {
    }
}
