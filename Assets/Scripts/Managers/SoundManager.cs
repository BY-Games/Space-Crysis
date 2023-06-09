using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /* This class manages all the sounds of the game. */

    public static SoundManager instance;

    [SerializeField]
    AudioClip[] muiscSound, effectSound, buttonSound;

    //musicSource handle backgorundMuisc
    //effectSource handle: lightbolt.
    //effectSource2 handle: saw,smoke 
    //effectSource3 handle: win, lose sound , wall,  pipe ,switch
    //buttonSource handle the sound button.
    [SerializeField] public AudioSource musicSource, effectSource, effectSource2, buttonSource , effectSource3;

    public bool musicSoundMuted = false, effectSoundMuted = false;
 


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
        musicSource.clip = muiscSound[0];
        musicSource.Play();
    }


    public void PlayEffect(int index)
    {
        effectSource.clip = effectSound[index];
        effectSource.Play();
      // effectSource.loop = true;

    }
    public void PlayEffect2(int index)
    {
        effectSource2.clip = effectSound[index];

        effectSource2.Play();
        effectSource2.loop = true;

    }
    public void PlayEffect3(int index)
    {
        effectSource3.clip = effectSound[index];

        effectSource3.Play();
      //  effectSource2.loop = true;

    }


    public void Stop()
    {


        effectSource.Stop();
        effectSource2.Stop();
        musicSource.Stop();
        effectSource3.Stop();


    }


    public void PlayMusic(int index)
    {
        musicSource.clip = muiscSound[index];
        musicSource.Play();
        musicSource.loop = true;

    }

    public void PlayButton(int index)
    {

        buttonSource.clip = buttonSound[index];
        buttonSource.Play();
    }



    public void ChangeMusicVolume(float value)
    {
        musicSource.volume = value;
    }

    public void ChangeEffectVolume(float value)
    {

        effectSource.volume = value;
        effectSource2.volume = value;
        buttonSource.volume = value;
        effectSource3.volume = value;

    }


    public void ToggleEffect()
    {
        effectSource.mute = !effectSource.mute;
        effectSource2.mute = !effectSource.mute;
        buttonSource.mute = !buttonSource.mute;
        effectSource3.mute = !effectSource.mute;

        effectSoundMuted = !effectSoundMuted;
    }


    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;

        musicSoundMuted = !musicSoundMuted;
        
    }


}
