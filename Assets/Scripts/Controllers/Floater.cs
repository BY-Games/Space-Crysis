using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class Floater : MonoBehaviour {
// User Inputs
    public float amplitude = 0.5f;
    public float frequency = 1f;

// Position Storage Variables
    Vector3 _posOffset = new Vector3();
    Vector3 _tempPos = new Vector3();

// Use this for initialization
    void Start() {
// Store the starting position & rotation of the object
        _posOffset = transform.position;
    }

// Update is called once per frame
    void Update() {
// Float up/down with a Sin()
        _tempPos = _posOffset;
        _tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = _tempPos;
    }
}