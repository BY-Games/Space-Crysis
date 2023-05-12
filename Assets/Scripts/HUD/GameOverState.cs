using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : MonoBehaviour
{
    private void Awake() {
        GameManager.OnGameStateChange += ShowGameOverOnState;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChange -= ShowGameOverOnState;
    }
    private void ShowGameOverOnState(GameManager.GameState state) {
        gameObject.SetActive(state is GameManager.GameState.OutOfTools);
    }
}
