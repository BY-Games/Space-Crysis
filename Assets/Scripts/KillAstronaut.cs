using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAstronaut : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Eliminated);
        }
    }

    private void OnParticleCollision(GameObject other) {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Tag Is Valid");

            GameManager.Instance.UpdateGameState(GameManager.GameState.Eliminated);
        }
    }
    
    
}