using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawMove : MonoBehaviour
{

    [SerializeField] float speed;

     Vector3 originalPosition;

    bool moveRIght = true;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (moveRIght)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x >= 0 ) {
            moveRIght=false;    
            }
        }
        else
        {
            transform.position = new Vector3(-1* (transform.position.x + Time.deltaTime), transform.position.y, transform.position.z);
            if (transform.position.x  == originalPosition.x)
            {
                moveRIght = true;
            }
        }
    }
}
