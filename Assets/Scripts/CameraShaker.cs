using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector3 posStrenght;
    [SerializeField] private Vector3 rotStrenght;

    public static event Action Shake;

    public static void Invoke()
    {
        Shake?.Invoke();
    }

    private void OnEnable() => Shake += CameraShake;
    private void OnDisable() => Shake -= CameraShake;
    private void CameraShake()
    {
        _camera.DOComplete();
        _camera.DOShakePosition(0.3f,posStrenght);
        _camera.DOShakeRotation(0.3f,posStrenght);
    }
}
