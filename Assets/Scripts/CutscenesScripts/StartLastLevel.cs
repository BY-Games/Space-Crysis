using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLastLevel : MonoBehaviour {
    [SerializeField] private GameObject astronaut;
    [SerializeField] private GameObject demoAstronaut;

    [SerializeField] private GameObject blackHole;

    [SerializeField] private GameObject wallHole;
    // Start is called before the first frame update
    void Start() {
        astronaut.SetActive(true);
        demoAstronaut.SetActive(false);
        // astronaut.GetComponent<AstronautController>().enabled = true;
        // astronaut.GetComponent<Collider2D>().enabled = true;
        
        blackHole.SetActive(true);
        wallHole.SetActive(true);
    }
}
