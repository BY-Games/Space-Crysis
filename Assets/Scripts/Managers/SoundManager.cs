using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  
    public static SoundManager instance;

    [SerializeField]
    AudioClip[] muiscSound, effectSound;

    [SerializeField] AudioSource musicSource, effectSource;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);    
        }
    }


    public void Start()
    {
        musicSource.clip = muiscSound[1];
        musicSource.Play(); 
    }


    public void PlayEffect(int index)
    {
        effectSource.clip = effectSound[index];
        effectSource.Play();

    }


    public void PlayMusic(int index)
    {
        musicSource.clip = muiscSound[index];
        musicSource.Play();
        musicSource.loop = true ;   
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ToggleEffect()
    {
        effectSource.mute = !effectSource.mute; 
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
}
