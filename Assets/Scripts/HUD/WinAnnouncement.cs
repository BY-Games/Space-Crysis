using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnnouncement : MonoBehaviour
{
    
/*
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            // announcement.gameObject.SetActive(true);
            GameManager.Instance.UpdateGameState(GameManager.GameState.Win);
        }
    }
*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // announcement.gameObject.SetActive(true);
            GameManager.Instance.UpdateGameState(GameManager.GameState.Win);

            SoundManager.instance.PlayEffect3(4);

        }
    }
}
