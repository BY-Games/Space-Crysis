using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SubSwitchController : MonoBehaviour {
    [FormerlySerializedAs("Blades")] [SerializeField] private Floater[] blades;
    [SerializeField] private GameObject switchOn;
    [FormerlySerializedAs("switchOf")] [SerializeField] private GameObject switchOff;

    // Start is called before the first frame update
    void Start() {
        switchOn.SetActive(false);
        switchOff.SetActive(true);
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Tool")) {
            Debug.Log("Here");
            switchOff.SetActive(false);
            switchOn.SetActive(true);
            foreach (Floater bladeFloater in blades) {
                bladeFloater.StopMove();
            
            }
        }
    }
}