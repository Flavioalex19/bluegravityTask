using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    IntroScreenManager IntroScreenManager;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        IntroScreenManager = GameObject.Find("Intro Screen Manager").GetComponent<IntroScreenManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadSequence();
        }
    }

    public void CanStartTheGame()
    {
        IntroScreenManager.canStartGame = true;
    }
    public void LoadSequence()
    {
        animator.SetTrigger("Start");
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
