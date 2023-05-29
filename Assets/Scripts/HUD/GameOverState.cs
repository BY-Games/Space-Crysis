using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : MonoBehaviour
{
    [SerializeField] GameObject OutOfToolsText;
    [SerializeField] GameObject EliminatedText;
    private void Awake()
    {
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
                Debug.Log("out of fffff");
                OutOfToolsText.gameObject.SetActive(true);
                EliminatedText.gameObject.SetActive(false);
                break;
            case GameManager.GameState.Eliminated:
                gameObject.SetActive(true);
                EliminatedText.gameObject.SetActive(true);
                OutOfToolsText.gameObject.SetActive(false);

                break;
            default:
                EliminatedText.gameObject.SetActive(false);
                OutOfToolsText.gameObject.SetActive(false);
                break;

        }
    }
}
