using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumSlider : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField] bool music, effect;
    // Start is called before the first frame update
    void Start()
    {

        if (music)
        {

            SoundManager.instance.ChangeMusicVolume(slider.value);

            slider.onValueChanged.AddListener(val => SoundManager.instance.ChangeMusicVolume(val));

        }
        else
        {
            SoundManager.instance.ChangeEffectVolume(slider.value);

            slider.onValueChanged.AddListener(val => SoundManager.instance.ChangeEffectVolume(val));
        }
    }

 
}
