using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get => instance;}
    [SerializeField] private AudioSource[] soundEffects;



    private void Awake()
    {
        AudioManager.instance = this;
    }

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].Play();
    }
}
