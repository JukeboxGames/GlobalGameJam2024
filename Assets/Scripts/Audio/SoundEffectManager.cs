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

    public void PlayPunchEffect()
    {
        int index = (int)Random.Range(1,100);
        
    }

    public void PlayWhooshEffect()
    {
        audioSource.volume = whooshSoundVolumen;
        audioSource.pitch = Random.Range(min_pitchWhoosh,max_pitchWhoosh);
        audioSource.clip = whooshSoundEffect;

        audioSource.Play();
    }
}
