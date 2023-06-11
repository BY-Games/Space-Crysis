using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSummary : MonoBehaviour {
    [SerializeField] private GameObject summaryPanel;
    [SerializeField] private ColliderInteract fixWall;

    public static LevelSummary Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

        GameManager.OnGameStateChange += ShowGameSummaryOnState;
    }


    private void OnDestroy() {
        GameManager.OnGameStateChange -= ShowGameSummaryOnState;
    }

    private void ShowGameSummaryOnState(GameManager.GameState state) {
        Debug.Log("Check Summary, current is " + state);
        if (state is not GameManager.GameState.Win) {
            fixWall.ResetObject();
            summaryPanel.gameObject.SetActive(false);
        }
        else {
        
            fixWall.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            fixWall.gameObject.SetActive(false);

            fixWall.gameObject.SetActive(true);
            Invoke(nameof(ActivatePanel), 3f);


         
        }

        
        
    }

    private void ActivatePanel() {
        if (GameManager.Instance.state is GameManager.GameState.Win) {
            
            summaryPanel.gameObject.SetActive(true);
         
        }
        
    }
}