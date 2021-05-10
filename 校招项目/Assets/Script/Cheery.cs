using Assets.Script.功能接口;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheery : ItemsBase
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            UIManager.Instance.Integral_Edition(this.item_fraction);

            UIManager.Instance.DestoryGameObject(this.gameObject);
        }
    }
}
