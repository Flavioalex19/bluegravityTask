using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{

    IntroScreenManager IntroScreenManager;
    // Start is called before the first frame update
    void Start()
    {
        IntroScreenManager = GameObject.Find("Intro Screen Manager").GetComponent<IntroScreenManager>();
    }

    public void CanStartTheGame()
    {
        IntroScreenManager.canStartGame = true;
    }
}
