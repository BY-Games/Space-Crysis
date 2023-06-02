using UnityEngine;
using System;
using System.Collections;
using Unity.VisualScripting;

public class Spring : MonoBehaviour
{

    public LayerMask playerLayerMask;
    public Transform rayCastStart;
    public Transform rayCastEnd;
    public float springForce = 1200.0f;

    private Animator animator;
    private float rayCastDistance;
    [SerializeField] GameObject player;

    private bool JumpInputActive;

    //	private bool JumpInputActive {
    //	get {
    //	return Input.GetKeyDown(KeyCode.Space);
    //}
    //	}


    /*
    [SerializeField] float jumpforce;




    }

    
      

        // Update is called once per frame
        void Update () {
            Debug.DrawLine (rayCastStart.position, rayCastEnd.position, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(rayCastStart.position, Vector2.right, rayCastDistance, playerLayerMask);
            //RaycastHit2D hit = Physics2D.Raycast(rayCastStart.position, Vector2.right, rayCastDistance);
            if (hit.collider != null && !animator.GetBool("Pressing"))
            {
                animator.SetBool("Pressing", true);
                animator.SetBool("Releasing", false);
                player = hit.collider.gameObject;
            }
            else if (hit.collider != null && animator.GetBool("Pressing") && JumpInputActive) {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, springForce));
                //player.rigidbody2D.AddForce(new Vector2(0, springForce));
            }
            else if (hit.collider == null) {
                animator.SetBool("Pressing", false);
                animator.SetBool("Releasing", true);
            }
        }

    */

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    public float forceMagnitude = 15f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) {
            JumpInputActive = true;
        } }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            JumpInputActive = false;
        }
    }

   void Update() { 
    Rigidbody2D otherRigidbody = player.GetComponent<Rigidbody2D>();

        if (JumpInputActive)
        {
       //    Vector3 totalForce = throwDirection * (dragDistance * dragMultiplier);
            Vector2 forceDirection = transform.up; 
            otherRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
           
        }
    }
}