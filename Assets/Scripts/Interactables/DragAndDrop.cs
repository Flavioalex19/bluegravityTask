using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int MyID = 0;
    public Image IconImage;
    public Transform dd_parentAfterDrag;
    public Item ActiveItem;

    private void Update()
    {
        
    }

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.tt_instance.ShowTooltip(ActiveItem.i_description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.tt_instance.HiddeTooltip();
    }
}
