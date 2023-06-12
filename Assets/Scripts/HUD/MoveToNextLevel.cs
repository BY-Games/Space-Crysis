using UnityEngine;



public class MoveToNextLevel : MonoBehaviour
{
    private void Start() {
        StartCoroutine(LevelManager.Instance.LoadScenes());
    }

    
}
