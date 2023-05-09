using System.Collections;
using TMPro;
using UnityEngine;

public class AstronautController : MonoBehaviour
{
    public GameObject throwObject;
    // public float maxDragDistance = 5f;
    [SerializeField] float dragMultiplier = 5f;
    [SerializeField] float linearDrag = 0.1f;
    [SerializeField] float angularDrag = 0.1f;

    //numer of item the player can throw
    [SerializeField] int maxItemToThrow = 3;

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject throwsLeft;
    [SerializeField] GameObject guide;


    private Rigidbody2D rb;
    private Vector3 dragStart;
    private Vector3 dragEnd;
    private bool isDragging = false;
    private float dragDistance = 0f;
    private int throwCounter = 0;
    private int counter;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = linearDrag;
        rb.angularDrag = angularDrag;

        gameOver.SetActive(false);

    }

    void Update()
    {
        if (throwCounter < maxItemToThrow)
        {

            if (Input.GetMouseButtonDown(0))
            {
                // Get the astronaut center position from the collider
                dragStart = gameObject.GetComponent<Collider2D>().bounds.center;
                // Set to dragging mode - ON
                isDragging = true;
                dragDistance = 0f;


            }
            else if (Input.GetMouseButton(0) && isDragging)
            {

                // get mouse position in every frame of holding mouse down.
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                // calculate distance from astrunaut to current point when releasing mouse press
                dragDistance = Vector3.Distance(mousePosition, dragStart);
                Vector3 dragArrowBody = (mousePosition - dragStart).normalized * dragDistance;
                dragEnd = dragStart + dragArrowBody;
            }
            else if (Input.GetMouseButtonUp(0) && isDragging)
            {
                isDragging = false;
                GameObject throwObj = Instantiate(throwObject, transform.position, Quaternion.identity);
                // get the rigidbody of object to throw 
                Rigidbody2D throwRb = throwObj.GetComponent<Rigidbody2D>();
                // direction vector for throwing object
                Vector3 throwDirection = (dragEnd - dragStart).normalized;
                // add force to the throwing object (Distance of dragged arrow, direction and extra force by developer choice)
                Vector3 TotalForce = throwDirection * dragDistance * dragMultiplier;
                throwRb.AddForce(TotalForce, ForceMode2D.Impulse);
                // add the opposite throw for the astronaut
                rb.AddForce(-TotalForce, ForceMode2D.Impulse);

                throwCounter++;
                counter = maxItemToThrow - throwCounter;

                throwsLeft.GetComponent<TMP_Text>().text = "x " + counter.ToString();
            }
        }
        // player throw more then he can.
        else if (gameOver != null)
        {
            if (guide != null)
            {
                guide.SetActive(false);
            }

            // Check if player is not moving 
            if (Mathf.Abs(rb.velocity.x) < 0.01f && Mathf.Abs(rb.velocity.y) < 0.01f)
            {
                Debug.Log("no more tool");
                gameOver.SetActive(true);
            }



        }




    }


}