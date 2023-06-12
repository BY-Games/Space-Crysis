using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTutorial : MonoBehaviour {
    [SerializeField] private GameObject player;
    private void Awake() {
        GameManager.OnGameStateChange += SetStopTimelineOnState;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChange -= SetStopTimelineOnState;
    }

    private void SetStopTimelineOnState(GameManager.GameState state) {
        if (state is not GameManager.GameState.Tutorial) {
            if (player != null) {
                player.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
