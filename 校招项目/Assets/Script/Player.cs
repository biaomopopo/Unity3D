using Assets.Script.功能接口;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour,MoveInterface
{
    //速度变量
    public int speed;

    //玩家的血量
    public int health_Value;

    //玩家的跳跃力
    public float jumping_Power;

    //玩家的生存状态
    public bool isLive;

    public GameObject up, down;

    public bool isgroud;

    //玩家移动函数
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
