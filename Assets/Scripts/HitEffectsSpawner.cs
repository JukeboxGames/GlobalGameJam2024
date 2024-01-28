using System;
using System.Collections;
using UnityEngine;

public class HitEffectsSpawner : MonoBehaviour
{
    [SerializeField] private Face face;
    // [SerializeField] private GameObject bloodEffects;
    // [SerializeField] private GameObject bruisesEffects;
    
    [SerializeField] private GameObject bloodParticleEffect;
    private void OnEnable()
    {
        face.HitPlayerEvent += HandlePlayerHit;
    }

    private void HandlePlayerHit()
    {
        CameraShaker.Invoke();

        Vector3 mousePosition = new(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
            0
        );

        bloodParticleEffect.transform.position = mousePosition;
        bloodParticleEffect.GetComponent<ParticleSystem>().Play();
    }

    private void OnDisable()
    {
        face.HitPlayerEvent -= HandlePlayerHit;
    }
}
