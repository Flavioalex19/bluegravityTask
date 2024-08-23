using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int MyID = 0;
    public Image IconImage;
    public Transform dd_parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        dd_parentAfterDrag = transform.parent;
        dd_parentAfterDrag.GetComponent<ItemSlot>().HasItem = false;
        MyID = dd_parentAfterDrag.GetComponent<ItemSlot>().SlotID;
        transform.SetParent(transform.root);
        transform.SetAsFirstSibling();
        IconImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(dd_parentAfterDrag);
        dd_parentAfterDrag.GetComponent<ItemSlot>().SlotID = MyID;
        IconImage.raycastTarget = true;

    }

    
}
