using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartDragDemo : MonoBehaviour {
    [SerializeField] private GameObject cursorDragDemo;

    [SerializeField] private GameObject parent;
    // Start is called before the first frame update
    
    void Start()
    {
        cursorDragDemo.gameObject.SetActive(true);
        Destroy(parent.gameObject);
    }

}
