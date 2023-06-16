using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Singleton Instance
    public static GameManager Instance;

    public GameState state;
    public PlayerState playerState;
    public static event Action<GameState> OnGameStateChange;

    public static event Action<PlayerState> OnPlayerStateChange;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            // Keep the component alive as long the program is active.
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void UpdateGameState(GameState newState) {
        state = newState;

        switch (newState) {
            case GameState.Menu:
                break;
            case GameState.Tutorial:
                break;
            case GameState.InGame:
                UpdatePlayerState(PlayerState.Alive);
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

    public void UpdatePlayerState(PlayerState newState) {
        playerState = newState;

        switch (newState) {
            case PlayerState.Alive:
                break;
            case PlayerState.Electrified:
                break;
            case PlayerState.Spiked:
                break;
            case PlayerState.Bladed:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        Debug.Log("Player State has Changed -> " + state);
        OnPlayerStateChange?.Invoke(newState);
    }


    // Update is called once per frame
    private void Update() {
        if (state == GameState.Tutorial) {
            if (Input.GetMouseButton(0)) {
                Debug.Log("Changed Here");
                UpdateGameState(GameState.InGame);
            }
        }
    }

    public enum PlayerState {
        Alive,
        Electrified,
        Spiked,
        Bladed
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