using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : MonoBehaviour {
    [SerializeField] private GameObject displayPanel;
    [SerializeField] GameObject OutOfToolsText;
    [SerializeField] GameObject EliminatedText;
    
    public static GameOverState Instance;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        GameManager.OnGameStateChange += ShowGameOverOnState;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= ShowGameOverOnState;
    }
    private void ShowGameOverOnState(GameManager.GameState state)
    {


        /*
        gameObject.SetActive(state is GameManager.GameState.OutOfTools);
        
        OutOfToolsText.SetActive(true);

        gameObject.SetActive(state is GameManager.GameState.Eliminated);
        EliminatedText.SetActive(true);
        */
        switch (state)
        {

            case GameManager.GameState.OutOfTools:
                gameObject.SetActive(true);
                displayPanel.gameObject.SetActive(true);
                Debug.Log("out of fffff");
                OutOfToolsText.gameObject.SetActive(true);
                EliminatedText.gameObject.SetActive(false);
                SoundManager.instance.PlayEffect3(8);

                break;
            case GameManager.GameState.Eliminated:
                gameObject.SetActive(true);
                displayPanel.gameObject.SetActive(true);
                EliminatedText.gameObject.SetActive(true);
                OutOfToolsText.gameObject.SetActive(false);

                SoundManager.instance.PlayEffect3(8);


                break;
            default:
                displayPanel.gameObject.SetActive(false);
                EliminatedText.gameObject.SetActive(false);
                OutOfToolsText.gameObject.SetActive(false);
                break;

        }
    }
}
