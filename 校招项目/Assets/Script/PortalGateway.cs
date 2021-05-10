using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGateway : MonoBehaviour
{
    public enum KindofGate
    {
        Gate1,
        Gate2,
        Gate3,
        Gate4
    }
    private bool CanCheckAnother;

    public KindofGate kindofGate;

    private void Start()
    {
        CanCheckAnother = true;

        UIManager.Instance.RegistPortalGateway(this);
    }

    //进入传送门
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (CanCheckAnother == true)
            {
                if (UIManager.Instance.FindSameGate(this).CanCheckAnother == true)
                {
                    collision.transform.position = UIManager.Instance.FindSameGate(this).transform.position;
                    CanCheckAnother = false;
                }
            }

        }
    }
    //出  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.FindSameGate(this).CanCheckAnother = true;
        }
    }
    
}
