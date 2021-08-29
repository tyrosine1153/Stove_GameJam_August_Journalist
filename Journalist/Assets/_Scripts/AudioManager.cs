using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : PersistentSingleton<AudioManager>
{
    public Slider slider;
    public BgmPlayer bgmPlayer;
    private AudioSource _audioSource;
    private Dictionary<string, AudioClip> _audioDictionary = new Dictionary<string, AudioClip>();
    float backVol = 1f;

    private void Start()
    {
        DontDestroyOnLoad(bgmPlayer);
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        _audioSource.volume = slider.value;
    }
    protected override void OnAwake()
    {
        _audioSource = GetComponent<AudioSource>();
        var clips = Resources.LoadAll<AudioClip>("Sounds");

        foreach (var clip in clips)
        {
            if (!_audioDictionary.ContainsKey(clip.name))
            {
                _audioDictionary.Add(clip.name, clip);
            }
        }
    }
    
    public bool PlaySound(string name)
    {
        if (_audioDictionary.TryGetValue(name, out AudioClip clip))
        {
            _audioSource.PlayOneShot(clip);
            return true;
        }

        return false;
    }

    public void PlaySound(BgmState state)
    {
        bgmPlayer.PlayBgm(state);
    }
}