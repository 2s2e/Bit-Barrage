using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    //Called before the start of the game
    void Awake() {

        //Only 1 AudioManager
        if(instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }
            
        //Doesn't cut off the music
        DontDestroyOnLoad(gameObject);

        //Loop through sounds array and adds an AudioSource component for each sound object
        foreach(Sound s in sounds) {
            //Calls the AudioSource from sound and add the elements to it
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = false;
        }
    }

    private void Start() {
            
        StartCoroutine(playBackgroundMusic());

    }

    IEnumerator playBackgroundMusic() {
        Debug.Log("Happened");
        Play("Background");
        yield return new WaitWhile(() => Array.Find(sounds, sound => sound.name == "Background").source.isPlaying);
        Play("Touhou");
        Debug.Log("Ended");
        
    }
    public void Play(string name) {
        //Look at sounds array, find the first sound object that matches the requirement of sound.name == name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
            return;
        s.source.Play();
    }
}
