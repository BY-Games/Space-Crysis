using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumSlider : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField] bool music, effect;
    // Start is called before the first frame update

    private const string MUSIC_VOLUME_KEY = "MusicVolume";
    private const string EFFECT_VOLUME_KEY = "EffectVolume";

    /*
     * When the scene is loaded, it checks if the slider value exists in the PlayerPrefs storage, and if it does,
     * it sets the slider value accordingly. When the slider value changes, it updates the SoundManager volume and also saves the new value to PlayerPrefs.
     */
    private void Start()
    {
        if (music)
        {
            //add the player preferences 
            if (PlayerPrefs.HasKey(MUSIC_VOLUME_KEY))
                slider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);

            //update sound manager 
            SoundManager.instance.ChangeMusicVolume(slider.value);

            // set value
            slider.onValueChanged.AddListener(val =>
            {
                SoundManager.instance.ChangeMusicVolume(val);
                PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, val);
            });
        }
        else
        {
            if (PlayerPrefs.HasKey(EFFECT_VOLUME_KEY))
                slider.value = PlayerPrefs.GetFloat(EFFECT_VOLUME_KEY);

            SoundManager.instance.ChangeEffectVolume(slider.value);

            slider.onValueChanged.AddListener(val =>
            {
                SoundManager.instance.ChangeEffectVolume(val);
                PlayerPrefs.SetFloat(EFFECT_VOLUME_KEY, val);
            });
        }
    }
}

