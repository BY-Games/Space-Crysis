using UnityEngine;


public class MoveToNextLevel : MonoBehaviour {
    [SerializeReference] private bool startActive;
    private void Start() {
        if (startActive) {
            Skip();
        }
        
    }

    public void Skip() {
        StartCoroutine(LevelManager.Instance.LoadScenes());
    }
}