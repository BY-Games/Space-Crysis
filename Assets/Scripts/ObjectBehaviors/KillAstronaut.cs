using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAstronaut : MonoBehaviour {
    [SerializeField] private GameManager.PlayerState obstacleEffect;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            SendEliminateReason();
            GameManager.Instance.UpdateGameState(GameManager.GameState.Eliminated);
        }
    }

    private void OnParticleCollision(GameObject other) {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Tag Is Valid");
            SendEliminateReason();
            GameManager.Instance.UpdateGameState(GameManager.GameState.Eliminated);
        }
    }

    private void SendEliminateReason() {
        GameManager.Instance.UpdatePlayerState(obstacleEffect);
    }
}