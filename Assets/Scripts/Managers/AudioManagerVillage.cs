using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerVillage : MonoBehaviour
{

    public  AudioSource audioSource;
    [SerializeField]  AudioClip BossAudioClip;
    [SerializeField] NPC boss;

    private void Update()
    {
        if (boss.isPlayerInRange)
        {
            ChangeAudioClip();
            audioSource.Play();
        }
    }
    public  void ChangeAudioClip()
    {
        audioSource.clip  = BossAudioClip;
        
    }
}
