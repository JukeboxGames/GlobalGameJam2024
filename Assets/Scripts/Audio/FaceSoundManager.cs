using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSoundManager : MonoBehaviour
{
    [SerializeField] SoundEffectManager soundEffects;
    [SerializeField] Face face;
    [SerializeField] private GameObject bloodEffect;
    [SerializeField] private List<Transform> faceParts;
    private void OnEnable() 
    {
       face.HitPlayerEvent     += HandlePlayerHit;
       face.NotHitPlayerEvent  += HandleNotPlayerHit;
    }

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckAllChilds();
        } 
    }

    private void CheckAllChilds()
    {
        foreach(Transform transform in faceParts)
        {
            if (transform.GetChild(0).TryGetComponent<ChildFeature>(out ChildFeature child))
            {
                if(child.OverMe) 
                { 
                    HandlePlayerHit(); 

                    Vector3 mousePosition = new(
                        Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                        Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                        0
                    );

                    bloodEffect.transform.position = mousePosition;
                    bloodEffect.GetComponent<ParticleSystem>().Play();
                }
            }
        }
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
