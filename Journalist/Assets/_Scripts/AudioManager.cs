using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoSingleton<AudioManager>
{
    public Slider slider;
    private AudioSource _audioSource;
    private Dictionary<string, AudioClip> _audioDictionary = new Dictionary<string, AudioClip>();
    float backVol = 1f;

    private void Start()
    {
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        slider.value = backVol;
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
            AudioSource tmp = GetComponent<AudioSource>();
            tmp.volume = slider.value;
            _audioSource.PlayOneShot(clip);
            return true;
        }

        return false;
    }
}