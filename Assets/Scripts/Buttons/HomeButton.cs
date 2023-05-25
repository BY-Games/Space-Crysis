using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
  
    public void home()
    {
        LevelManager.Instance.ResetCurrentSceneIndex();

        //return to menu 
        LevelManager.Instance.LoadScene(0);
   
    }

}
