using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : MonoBehaviour {
    [SerializeField] private GameObject astronaut;
    // Start is called before the first frame update
    void Start() {
        Rigidbody2D rb = astronaut.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
