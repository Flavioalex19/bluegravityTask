/// <summary>
/// Script made by Flavio Alexandre
/// This is script is responsible to manage the simple dialogue system
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI _lineText;
    
    public void Dialogue(List<string> list, int index, bool isPanelOn, TextMeshProUGUI mytext)
    {
        _lineText = mytext;
        //only goes forward if the dialogue panel is on display
        if (isPanelOn)
        {
            if (index < list.Count)
            {
                StartCoroutine(TypeSentence(list[index], _lineText));
            }
            else isPanelOn = false;
        }


    }


    //function for dialogue - create the effect of typing the sentence
    public IEnumerator TypeSentence(string sentence, TextMeshProUGUI GUItext)
    {
        GUItext.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            GUItext.text += letter;
            yield return new WaitForSeconds(.01f);
        }
    }
}
