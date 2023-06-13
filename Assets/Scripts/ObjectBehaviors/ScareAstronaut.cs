using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScareAstronaut : MonoBehaviour {
    [FormerlySerializedAs("astronaut")] [SerializeField]
    private PlayerAnimationState astronautAnim;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            astronautAnim.ScaredAnimation();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            astronautAnim.StopScaredAnimation();
        }
    }

    // Update is called once per frame
    void Update() { }
}