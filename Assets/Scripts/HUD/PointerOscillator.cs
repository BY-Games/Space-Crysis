using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerOscillator : MonoBehaviour {
    [SerializeReference] private bool horizontal = false;
    [SerializeField] private float range = 0.1f;
    [SerializeField] private uint speed = 2;
    float axis = 0;
    float point;


    // Update is called once per frame
    void Update() {
        // Debug.Log(transform.position);
        float sinCycle = (2 * Mathf.PI);
        axis = (axis % sinCycle) + Time.deltaTime * speed;
        point = Mathf.Sin(axis) * range;
        if (horizontal) {
            GetComponent<Transform>().position =
                new Vector3(transform.position.x  + point, transform.position.y, transform.position.z);
        }
        else {
            GetComponent<Transform>().position =
                new Vector3(transform.position.x, transform.position.y + point, transform.position.z);
        }
    }
}