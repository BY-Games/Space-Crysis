using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FixTableState : MonoBehaviour {
    [FormerlySerializedAs("fixTableState")] [SerializeField] private GameObject table;
    // Start is called before the first frame update
    private void OnDestroy() {
        Color tableColor = table.GetComponent<SpriteRenderer>().color;
        tableColor.a = 1f; // Set alpha value to 1 (fully opaque)
        table.GetComponent<SpriteRenderer>().color = tableColor;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
