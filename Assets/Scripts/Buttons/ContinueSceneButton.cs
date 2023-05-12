using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueSceneButton : MonoBehaviour
{
    public void ChangeScene(string sceneName) {
        // LevelManager.Instance.LoadScene(sceneName);
        StartCoroutine(LevelManager.Instance.LoadScenes());
    }
}
