using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LockRotation : MonoBehaviour {
    private Quaternion currentRotation;
    private Vector3 currentPosition;

    // Start is called before the first frame update
    void Start() {
        currentRotation = gameObject.transform.rotation;
        currentPosition = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update() {
        if (gameObject.transform.rotation != currentRotation) {
            gameObject.transform.rotation = currentRotation;
            gameObject.transform.localPosition = currentPosition;
        }
    }
}