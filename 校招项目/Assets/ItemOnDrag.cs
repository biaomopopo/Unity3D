using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    //记录刚开时物体的父物体位置
    private Transform originTranposition;

    public Inventory myBag;

    int currentId;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originTranposition = transform.parent;

        currentId = originTranposition.GetComponent<Slot>().slotID;

        transform.SetParent(transform.parent.parent);

        Debug.Log("格子的ID为：" + currentId);
        
        transform.position = eventData.position;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "物品的图片")
            {
                var tmp = myBag.itemsList[currentId];

                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);

                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                myBag.itemsList[currentId] = myBag.itemsList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];

                myBag.itemsList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = tmp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originTranposition.position;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originTranposition);

                GetComponent<CanvasGroup>().blocksRaycasts = true;

                return;
            }

            if(eventData.pointerCurrentRaycast.gameObject.name == "物品栏")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);

                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                myBag.itemsList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = myBag.itemsList[currentId];

                if (eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID != currentId)
                    myBag.itemsList[currentId] = null;

                GetComponent<CanvasGroup>().blocksRaycasts = true;

                return;
            }
        }

        transform.SetParent(originTranposition);

        transform.position = originTranposition.position;

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
   
}
