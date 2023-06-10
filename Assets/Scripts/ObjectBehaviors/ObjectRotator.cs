using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectRotator : MonoBehaviour {
    [FormerlySerializedAs("directionUp")] [SerializeReference] private bool directionRight;

    [SerializeField] private float speed;

    private Transform _transform;
    // Start is called before the first frame update
    void Start() {
        _transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (directionRight) {
            //change the Z-axis 
            _transform.Rotate(0, 0, speed * Time.deltaTime);
        }
        else {
            _transform.Rotate(0, 0, -speed * Time.deltaTime);
        }
    }
}
