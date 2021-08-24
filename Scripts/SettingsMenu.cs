using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    void Start() {
        slider.value = PlayerPrefs.GetFloat("MyExposedParam", 0.75f);
    }

    public void SetVolume(float volume) {
        // Debug.Log(volume);
        audioMixer.SetFloat("MyExposedParam", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MyExposedParam", volume);
    }
}
