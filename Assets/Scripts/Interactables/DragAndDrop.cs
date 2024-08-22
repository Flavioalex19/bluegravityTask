using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image IconImage;
    public Transform dd_parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        dd_parentAfterDrag = transform.parent;
        dd_parentAfterDrag.GetComponent<ItemSlot>().HasItem = false;
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
        IconImage.raycastTarget = true;
    }

    
}
