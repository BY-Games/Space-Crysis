using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerOscillator : MonoBehaviour
{
   
    float range = 0.1f;
     uint speed = 2;
    float axis = 0;
    float point;    


    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
        axis = (axis % (2*Mathf.PI)) + Time.deltaTime * speed;
        point = Mathf.Sin(axis) * range;
        GetComponent<Transform>().position = new Vector3(transform.position.x,transform.position.y + point,transform.position.z); 
       
    }
}
