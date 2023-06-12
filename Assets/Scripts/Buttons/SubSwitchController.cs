using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SubSwitchController : MonoBehaviour
{
    [FormerlySerializedAs("Blades")]
    [SerializeField]
    private Floater[] blades;

    [SerializeField] private GameObject switchOn;

    [FormerlySerializedAs("switchOf")]
    [SerializeField]
    private GameObject switchOff;

    private bool swithSoundHappendBefore = false;

    // Start is called before the first frame update
    void Start()
    {
        switchOn.SetActive(false);
        switchOff.SetActive(true);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {


        Debug.Log("Here");
        switchOff.SetActive(false);
        switchOn.SetActive(true);

        if (!swithSoundHappendBefore)
        {
            SoundManager.instance.PlayEffect3(6);
            swithSoundHappendBefore = true;
        }
        foreach (Floater bladeFloater in blades)
        {
            bladeFloater.StopMove();
        }
    }
}