using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautDead : MonoBehaviour
{
    private void Start()
    {
        //subscribe the HandleGameStateChange method as a listener to the GameManager.OnGameStateChange event
        GameManager.OnGameStateChange += HandleGameStateChange;
    }

    // called after the script is destroyed or disabled
    private void OnDestroy()
    {
        //stopping it from being invoked.
        GameManager.OnGameStateChange -= HandleGameStateChange;
    }

    private void HandleGameStateChange(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Eliminated)
        {
            StartCoroutine(WaitAndDeactivate());
        }
    }

    private IEnumerator WaitAndDeactivate()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
}
