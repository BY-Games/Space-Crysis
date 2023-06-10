using System;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.Serialization;

// Makes objects float up & down while gently spinning.
public class Floater : MonoBehaviour {
    [FormerlySerializedAs("stopMove")] private bool stopMoveState = false;
    [SerializeReference] private bool collisionSensitive = false;

    private void OnCollisionEnter2D(Collision2D other) {
        if (collisionSensitive) {
            enabled = false;
        }
    }

    // User Inputs
    public float amplitude = 0.1f;
    public float frequency = 0.4f;

// Position Storage Variables
    Vector3 _posOffset = new Vector3();
    Vector3 _tempPos = new Vector3();
    private float _minPos;

    public void StopMove() {
        stopMoveState = true;
        frequency = 1f;
    }

// Use this for initialization
    void Start() {
// Store the starting position & rotation of the object
        _posOffset = transform.position;
        _minPos = _posOffset.y - amplitude;
        Debug.Log("Min Pos -> " + _minPos);
    }

// Update is called once per frame
    void Update() {
// Float up/down with a Sin()
        _tempPos = _posOffset;

        _tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        if (stopMoveState) {
            if (Math.Abs(_tempPos.y - _minPos) < Mathf.Epsilon) {
                enabled = false;
            }
        }

        transform.position = _tempPos;
    }
}