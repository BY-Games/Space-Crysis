using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSummary : MonoBehaviour {
    [SerializeField] private GameObject summaryPanel;

    public static LevelSummary Instance;
    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        GameManager.OnGameStateChange += ShowGameSummaryOnState;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChange -= ShowGameSummaryOnState;
    }

    private void ShowGameSummaryOnState(GameManager.GameState state) {
        Debug.Log("Check Summary, current is " + state);
        summaryPanel.gameObject.SetActive(state == GameManager.GameState.Win);
    }
}
