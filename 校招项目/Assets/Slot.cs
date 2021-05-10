using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item soltItem;

    public Image slotImage;

    public Text soltNum;

    public GameObject itemInSlot;

    string soltInfo;

    public int slotID;

    public void ItemOnClicked()
    {
        BagManager.UpdateItemInfo(soltInfo);
    }

    public void SetupSlot(Item item)
    {
        if(item == null)
        {
            itemInSlot.SetActive(false);

            return;
        }

        slotImage.sprite = item.itemSprite;

        soltNum.text = item.itemCount.ToString();

        soltInfo = item.itemInfo;
    }

}
