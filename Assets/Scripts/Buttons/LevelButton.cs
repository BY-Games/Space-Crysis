using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour
{

    [SerializeField] int sceneIndex;

    //[SerializeField] TextMeshPro levelText;
    [SerializeField] Transform textContainer; // Reference to the child object containing the TextMeshPro component

    private TextMeshProUGUI levelText;

    void Start()
    {
        sceneIndex--;

        // Get the TextMeshPro component from the child object
        levelText = textContainer.GetComponentInChildren<TextMeshProUGUI>();

        // Set the text of the button based on the scene index
        levelText.text = sceneIndex.ToString();
       // levelText.text  = sceneIndex.ToString();
    }

    public void LoadScene()
    {
       // LevelManager.Instance.LoadScene(sceneIndex)
       
       LevelManager.Instance.setCurrentIndex(sceneIndex);
       StartCoroutine(LevelManager.Instance.LoadScenes());


    }



}
