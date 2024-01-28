using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    
    public static MusicPlayer Instance
    {
        get;
        private set;
    }

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            audioSource = GetComponent<AudioSource>();

        }

        
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
        if (scene.name == "SampleScene") {
            audioSource.Stop();
        } else {
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        }
    }

    private void Update() {
        audioSource.volume = Settings.Instance.masterVolume;
    }
}
