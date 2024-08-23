using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{

    public static TooltipManager tt_instance;
    public TextMeshProUGUI tt_ItemDescription;
    private void Awake()
    {
        if(tt_instance!=null && tt_instance != this)Destroy(this.gameObject);
        else tt_instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void ShowTooltip(string message)
    {
        gameObject.SetActive(true);
        tt_ItemDescription.text = message;
    }
    public void HiddeTooltip()
    {
        gameObject.SetActive(false);
        tt_ItemDescription.text = string.Empty;
    }
}
