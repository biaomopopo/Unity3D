using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float time;

    private bool isTrap;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTrap = true;

        this.GetComponent<BoxCollider2D>().isTrigger = false;

        Debug.Log("触发掉落陷阱");
    }

    private void Update()
    {
        if(!isTrap)
        {
            return;
        }

        time -= Time.deltaTime;

        if(time <= 0)
        {
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

}
