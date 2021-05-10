using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPack : MonoBehaviour
{
    public bool isPack;

    public GameObject packGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PackKeyCode();
    }

    //°´ÏÂ°´¼ü
    public void PackKeyCode()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            isPack = !isPack;

            if(isPack)
            {
                packGameObject.SetActive(true);
            }
            else
            {
                packGameObject.SetActive(false);
            }

           
        }
    }

}
