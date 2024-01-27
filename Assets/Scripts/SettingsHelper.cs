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
        mouseSensitivitySlider.value = Settings.Instance.mouseSensitivity;
    }

    public void SetMasterVolume(){
        Settings.Instance.masterVolume = (int)volumeSlider.value;
        Debug.Log(Settings.Instance.masterVolume);
    }

    public void SetMouseSensitivity(){
        Settings.Instance.mouseSensitivity = (int)mouseSensitivitySlider.value;
        Debug.Log(Settings.Instance.mouseSensitivity);
    }
}
