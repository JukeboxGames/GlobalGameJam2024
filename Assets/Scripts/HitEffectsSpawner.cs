using System;
using System.Collections;
using UnityEngine;

public class HitEffectsSpawner : MonoBehaviour
{
    [SerializeField] private Face face;
    [SerializeField] private GameObject bloodEffects;
    [SerializeField] private GameObject bruisesEffects;
    private void OnEnable()
    {
        face.HitPlayerEvent += HandlePlayerHit;
    }

    private void HandlePlayerHit()
    {
        int index = (int)UnityEngine.Random.Range(1,100);

        if (index > 60)
        {
            if (index > 85)
            {
                
            } else{

            }
        }
    }

    private void OnDisable()
    {
        face.HitPlayerEvent -= HandlePlayerHit;
    }
}
