using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    public static BagManager instace;

    public Text bagTextInfo;

    public Inventory myBag;

    public GameObject soltGrid;

    public List<GameObject> slots = new List<GameObject>();

    public GameObject emptySlot;

    //public Slot slotPrefab;

    private void Awake()
    {
        if(instace != null)
        {
            Destroy(this);
        }

        instace = this;
    }

    private void OnEnable()
    {
        Refresh();

        instace.bagTextInfo.text = "这是我的背包";
    }

    public static void UpdateItemInfo(string info)
    {
        instace.bagTextInfo.text = info;
    }

    //public static void CreateNewItem(Item item)
    //{
    //    Slot slot = Instantiate(instace.slotPrefab, instace.soltGrid.transform.position, Quaternion.identity);

    //    slot.gameObject.transform.SetParent(instace.soltGrid.transform);

    //    slot.soltItem = item;

    //    slot.slotImage.sprite = item.itemSprite;

    //    slot.soltNum.text = item.itemCount.ToString();
    //}
    //刷新背包
    public static void Refresh()
    {
        for (int i = 0; i < instace.soltGrid.transform.childCount; i++)
        {
            if (instace.soltGrid.transform.childCount == 0)
                break;

            Destroy(instace.soltGrid.transform.GetChild(i).gameObject);

            instace.slots.Clear();
        }

        for (int i = 0; i < instace.myBag.itemsList.Count; i++)
        {
            //CreateNewItem(instace.myBag.itemsList[i]);

            instace.slots.Add(Instantiate(instace.emptySlot));

            instace.slots[i].transform.SetParent(instace.soltGrid.transform);

            instace.slots[i].GetComponent<Slot>().slotID = i;

            instace.slots[i].GetComponent<Slot>().SetupSlot(instace.myBag.itemsList[i]);
        }
    }
}
