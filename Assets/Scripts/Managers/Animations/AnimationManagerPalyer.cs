using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerPalyer : MonoBehaviour
{
    //Components
    Animator _playerAnimator;
    PlayerController p_PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        p_PlayerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
    }
    void UpdateAnimation()
    {
        _playerAnimator.SetFloat("moveX", p_PlayerController._move.x);
        _playerAnimator.SetFloat("moveY", p_PlayerController._move.y);
    }
}
