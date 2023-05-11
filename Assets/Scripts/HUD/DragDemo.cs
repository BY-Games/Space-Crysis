using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDemo : MonoBehaviour
{
    [SerializeField] Transform player;

    private void Awake() {
        GameManager.OnGameStateChange += GameManagerOnGameChange;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChange -= GameManagerOnGameChange;
    }

    private void GameManagerOnGameChange(GameManager.GameState state) {
        if (state == GameManager.GameState.InGame) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Current position - " + transform.position);
        
        transform.position = Camera.main.WorldToScreenPoint(player.GetComponent<Collider2D>().bounds.center);
        Debug.Log("Swiched to position - " + player.position);
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(Input.GetMouseButton(0)) {
    //         Destroy(this.gameObject);
    //     }
    // }
}
