using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //GameObject droppedObj = eventData.pointerDrag;
        if(transform.childCount == 0)
        {
            DragAndDrop dd_item = eventData.pointerDrag.GetComponent<DragAndDrop>();
            dd_item.dd_parentAfterDrag = transform;
        }
        /*
        DragAndDrop dd_item = droppedObj.GetComponent<DragAndDrop>();
        dd_item.dd_parentAfterDrag = transform;
        */
    }
}
