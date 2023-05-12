using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialState : MonoBehaviour
{
    
    private void Awake() {
        GameManager.OnGameStateChange += ShowTutorialToolsOnState;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChange -= ShowTutorialToolsOnState;
    }
    private void ShowTutorialToolsOnState(GameManager.GameState state) {
        gameObject.SetActive(state is GameManager.GameState.Tutorial or GameManager.GameState.InGame);
    }
}
