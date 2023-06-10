using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumSlider : MonoBehaviour
{

    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {

        SoundManager.instance.ChangeMasterVolume(slider.value);
        slider.onValueChanged.AddListener(val => SoundManager.instance.ChangeMasterVolume(val));
    }

 
}
