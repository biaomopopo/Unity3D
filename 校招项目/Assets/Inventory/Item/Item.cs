using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public int itemCount;

    public string itemName;

    public Sprite itemSprite;

    public string itemInfo;
}
