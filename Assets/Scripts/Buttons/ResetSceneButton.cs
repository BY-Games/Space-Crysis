using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneButton : MonoBehaviour
{
    public void ResetScene()
    {
        // Get the name of the current scene
        string sceneName = SceneManager.GetActiveScene().name;
        GameManager.Instance.UpdateGameState(GameManager.GameState.Tutorial);

        // Load the current scene again
        SceneManager.LoadScene(sceneName);
    }
}
