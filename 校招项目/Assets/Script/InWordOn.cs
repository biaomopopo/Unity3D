using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWordOn : MonoBehaviour
{
    public Item item;

    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Add();

        Destroy(this.gameObject);
    }

    void Add()
    {
        if(!inventory.itemsList.Contains(item))
        {
            for (int i = 0; i < inventory.itemsList.Count; i++)
            {
                if(inventory.itemsList[i] == null)
                {
                    inventory.itemsList[i] = item;

                    break;
                }
            }
        }
        else
        {
            item.itemCount++;
        }
        BagManager.Refresh();
    }
}
