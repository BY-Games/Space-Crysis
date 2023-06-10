using UnityEngine;

public class StopActionOnWin : MonoBehaviour {
    private void Awake() {
        GameManager.OnGameStateChange += SetOnObjectActionState;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChange -= SetOnObjectActionState;
    }

    private void SetOnObjectActionState(GameManager.GameState state) {
        gameObject.SetActive(state is not GameManager.GameState.Win);
    }
}