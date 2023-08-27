using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioName
{
    ButtonClick,
    Background,
    LaserBeam,
    CheckPoint,
    GameOver,
    LevelComplete,
    Caught
}

[Serializable]
public class AudioType
{
    public AudioName audioName;
    public AudioClip audioClip;
}

public class Audio_Manager : MonoBehaviour
{
    [SerializeField] private AudioSource SFX;
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource Laser;
    [SerializeField] private AudioType[] Audio;

    private static Audio_Manager instance;
    public static Audio_Manager Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBG(AudioName.Background);
    }


    public void PlayBG(AudioName name)
    {
        AudioClip audioClip = getAudioClip(name);
        if(audioClip !=null)
        {
            BGM.clip = audioClip;
            BGM.Play();
        }
        else
        {
            Debug.Log("Audio not found");
        }
    }

    public void PlaySFX(AudioName name)
    {
        AudioClip audioClip = getAudioClip(name);
        if(audioClip!=null)
        {
            SFX.clip = audioClip;
            SFX.PlayOneShot(audioClip);
        }
        else
        {
            Debug.Log("SFX not found");
        }
    }

    public void PlayerLaserSound(AudioName name)
    {
        AudioClip audioClip = getAudioClip(name);
        if(audioClip!=null)
        {
            Laser.clip = audioClip;
            Laser.Play();
        }
        else
        {
            Debug.Log("Laser Audio not found");
        }

    }

    private AudioClip getAudioClip(AudioName name)
    {
        AudioType audioType = Array.Find(Audio, item => item.audioName == name);
        if (audioType != null)
            return audioType.audioClip;
        return null;
    }

    public void StopAllSoundsExceptBG()
    {
        SFX.Stop();
        Laser.Stop();
    }

    public void SetBGVolume(float volume)
    {
        BGM.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        SFX.volume = volume;
        Laser.volume = volume;
    }
}
