using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public GameState state;
    public static event Action<GameState> OnGameStateChange;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start() {
        UpdateGameState(GameState.Tutorial);
    }

    public void UpdateGameState(GameState newState) {
        state = newState;

        switch (newState) {
            case GameState.Menu:
                break;
            case GameState.Tutorial:
                break;
            case GameState.InGame:
                break;
            case GameState.OutOfTools:
                break;
            case GameState.Eliminated:
                break;
            case GameState.Win:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        Debug.Log("State has Changed -> " + state);
        OnGameStateChange?.Invoke(newState);
    }


    // Update is called once per frame
    private void Update() {
        if (state == GameState.Tutorial) {
            if(Input.GetMouseButton(0)) {
                Debug.Log("Changed Here");
                UpdateGameState(GameState.InGame);
            }
        }
    }

    public enum GameState {
        Menu,
        Tutorial,
        InGame,
        OutOfTools,
        Eliminated,
        Win,
    }
}