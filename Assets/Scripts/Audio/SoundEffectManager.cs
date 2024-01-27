using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{   
    [Header("References")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] List<AudioClip> normalPunchSoundEffects;
    [SerializeField] List<AudioClip> rarePunchSoundEffects;
    [SerializeField] List<AudioClip> epicPunchSoundEffects;
    [SerializeField] List<AudioClip> legendaryPunchSoundEffects;
    [SerializeField] AudioClip whooshSoundEffect;

    [Header("Settings")]
    [SerializeField] private float punchSoundVolumen;
    [SerializeField] private float whooshSoundVolumen;
    [SerializeField] private float min_pitchWhoosh;
    [SerializeField] private float max_pitchWhoosh;

    private AudioClip punchEffect;
    public void PlayPunchEffect()
    {
        SetPunchEffectClip();

        audioSource.clip = punchEffect;
        audioSource.volume = punchSoundVolumen;
        audioSource.Play();
    }

    public void PlayWhooshEffect()
    {
        audioSource.volume = whooshSoundVolumen;
        audioSource.pitch = Random.Range(min_pitchWhoosh,max_pitchWhoosh);
        audioSource.clip = whooshSoundEffect;

        audioSource.Play();
    }

    private void SetPunchEffectClip()
    {
        int index = (int)Random.Range(1,100);
        //print(index);
        if (index < 60)
        {
            punchEffect = normalPunchSoundEffects[Random.Range(0,normalPunchSoundEffects.Count)];
        }

        if (index >= 60 && index < 80)
        {
            punchEffect = rarePunchSoundEffects[Random.Range(0,rarePunchSoundEffects.Count)];
        }
        
        if (index >= 80 && index < 97)
        {
            punchEffect = epicPunchSoundEffects[Random.Range(0,epicPunchSoundEffects.Count)];
        }

        if (index >= 97)
        {
            punchEffect = legendaryPunchSoundEffects[Random.Range(0,legendaryPunchSoundEffects.Count)];
        }
    }
}
