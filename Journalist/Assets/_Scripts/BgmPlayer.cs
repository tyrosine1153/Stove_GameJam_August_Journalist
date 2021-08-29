using System;
using UnityEngine;

public enum BgmState
{
    Home = 0,
    Game,
    Ending,
}

[RequireComponent(typeof(AudioSource))]
public class BgmPlayer : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        PlayBgm(BgmState.Home);
    }

    public void PlayBgm(BgmState state)
    {
        audioSource.clip = state switch
        {
            BgmState.Home => clips[0],
            BgmState.Game => clips[1],
            BgmState.Ending => clips[2],
            _ => null
        };
        
        audioSource.Play();
    }
}