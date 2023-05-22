using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
    public void Play()
    {
        //set the next scence in the order of the build. 
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        StartCoroutine(LevelManager.Instance.LoadScenes());
    }
}
