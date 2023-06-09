using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{

    [SerializeField] bool toggleMusic, toggleEffects;


    public void Toggle()
    {
        if (toggleMusic) SoundManager.instance.ToggleMusic();

        if (toggleEffects) SoundManager.instance.ToggleEffect();
    }
}
