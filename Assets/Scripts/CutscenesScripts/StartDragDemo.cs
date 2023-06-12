using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartDragDemo : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cursorDragDemo;
    [SerializeField] private GameObject dragArrowDemo;

    [SerializeField] private GameObject parent;
    // Start is called before the first frame update
    
    void Start()
    {
        player.gameObject.SetActive(true);

        cursorDragDemo.gameObject.SetActive(true);
        dragArrowDemo.gameObject.SetActive(true);
        Destroy(parent.gameObject);
    }

}
