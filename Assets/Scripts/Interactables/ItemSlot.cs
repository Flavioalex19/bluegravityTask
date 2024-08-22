using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public int SlotID;
    public bool HasItem = false;
    public Sprite ItemSprite;

    //Testing awake
    private void Awake()
    {
        
        
    }

    private void Update()
    {
        /*//Check if has an item
        if (transform.childCount == 0) HasItem = false;
        else HasItem = true;
        */
        if (HasItem)
        {
            //SlotID = transform.GetChild(0).
            ItemSprite = transform.GetChild(0).GetComponent<DragAndDrop>().IconImage.sprite;
        }
        else ItemSprite = null;

       

    }
    public void OnDrop(PointerEventData eventData)
    {
        //GameObject droppedObj = eventData.pointerDrag;
        if(transform.childCount == 0)
        {
            DragAndDrop dd_item = eventData.pointerDrag.GetComponent<DragAndDrop>();
            dd_item.dd_parentAfterDrag = transform;
            HasItem = true;
            
        }
        /*
        DragAndDrop dd_item = droppedObj.GetComponent<DragAndDrop>();
        dd_item.dd_parentAfterDrag = transform;
        */
    }

    
}
