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
    public Button btn_CastDMG;
    public Button btn_Remove;

    public GameManager gm_gameManager;

    BattleAi battleAi;//Only on the battle scene

    private void Start()
    {
       
        gm_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        btn_CastDMG.onClick.AddListener(() => DMG());
        
    }

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

    public void DMG()
    {
        //Will only be executed at the battle Scene
        if (gm_gameManager.gm_IsABattle && transform.parent.GetComponent<ItemSlot>().IsInBattle)
        {
            //The idea is that is the value of the damege is positive, the effect will heal the player, otherwise the effect will damage the opponent
            if (ActiveItem.i_damage > 0) print("Heal");
            else 
            {
                print("Do DMG");
                //BattleAi battleAi = GameObject.Find("Enemy").GetComponent<BattleAi>();
                battleAi.TakeDamage(ActiveItem.i_damage);
            }
            
            //return ActiveItem.i_damage;
        }
        else print("No use");
        
    }
   
}
