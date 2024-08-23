using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class TrasitionNewLevel : MonoBehaviour
{
    static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void Transition()
    {
        anim.SetTrigger("Go");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
