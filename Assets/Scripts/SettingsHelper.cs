using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHelper : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider mouseSensitivitySlider;

    private void OnEnable() {
        volumeSlider.value = Settings.Instance.masterVolume;
    }

    public void SetMasterVolume(){
        Settings.Instance.masterVolume = volumeSlider.value;
    }

    public void SetMouseSensitivity(){
        Settings.Instance.mouseSensitivity = mouseSensitivitySlider.value;
    }
}
