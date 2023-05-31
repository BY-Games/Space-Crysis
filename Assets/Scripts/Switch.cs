using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject greenSwitch;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            greenSwitch.gameObject.SetActive(true);
            gameObject.SetActive(false);
            
        }
    }


 
}
