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
        LevelManager.Instance.setCurrentIndex(0);

        StartCoroutine(LevelManager.Instance.LoadScenes());

       // SoundManager.instance.PlayMusic(0);
       
    }

    public void Quit()
    {
       
        Application.Quit();
        Debug.Log("Player has Quite the Game");

    }
}
