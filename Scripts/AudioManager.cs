using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider slider;
    public Sound[] sounds;
    // public SettingsMenu setVolume;
    public static AudioManager instance; //creeaza 2 audio manageri
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            if(s.source.name != "PlayerWalk") {
                s.source.loop = s.loop;
            }
            
        }
    }


    void Start() {
        Play("Theme");
        slider.value = PlayerPrefs.GetFloat("MyExposedParam", 0.75f);
    }

    // Update is called once per frame
   public void Play(string name) {
       Sound s = Array.Find(sounds, sound => sound.name == name);
       if(s == null) {
           Debug.LogWarning("Sound: " + name + " not found!");
           return;
       }
        s.source.Play();
   }

   public void Stop(string name) {
       Sound s = Array.Find(sounds, sound => sound.name == name);
       if(s == null) {
           Debug.LogWarning("Sound: " + name + " not found!");
           return;
       }
       s.source.Stop();
   }

   public void SetVolume(float volume) {
        // Debug.Log(volume);
        audioMixer.SetFloat("MyExposedParam", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MyExposedParam", volume);
    }
}
