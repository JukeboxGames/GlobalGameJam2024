using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSoundManager : MonoBehaviour
{
    [SerializeField] SoundEffectManager soundEffects;
    [SerializeField] Face face;
    private void OnEnable() 
    {
       face.HitPlayerEvent     += HandlePlayerHit;
       face.NotHitPlayerEvent  += HandleNotPlayerHit;
    }
    private void HandlePlayerHit()
    {
        soundEffects.PlayPunchEffect();
    }
    private void HandleNotPlayerHit()
    {
        soundEffects.PlayWhooshEffect();
    }
    private void OnDisable() 
    {
        face.HitPlayerEvent     -= HandlePlayerHit;
        face.NotHitPlayerEvent  -= HandleNotPlayerHit;
    }
}
