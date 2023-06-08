using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

// Makes objects float up & down while gently spinning.
public class Floater : MonoBehaviour {
    [FormerlySerializedAs("stopMove")] private bool stopMoveState = false;

// User Inputs
    public float amplitude = 0.5f;
    public float frequency = 1f;

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
        Debug.Log(_tempPos.y);

        if (stopMoveState) {
            if (Math.Abs(_tempPos.y - _minPos) < Mathf.Epsilon) {
                enabled = false;
            }
        }

        transform.position = _tempPos;
    }
}