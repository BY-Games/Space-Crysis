using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawMove : MonoBehaviour
{

    [SerializeField] float speed =0.5f;

    Vector3 originalPosition;

    bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (moveRight)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x >= 0)
            {
                moveRight = false;
            }
        }
        else
        {

            transform.position = new Vector3(((transform.position.x) - speed * Time.deltaTime), transform.position.y, transform.position.z);
            Debug.Log(transform.position);

            if (transform.position.x <= originalPosition.x)
            {
                moveRight = true;
            }
        }
    }
}
