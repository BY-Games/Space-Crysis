using UnityEngine;

public class SecondController : MonoBehaviour
{
    public GameObject throwObject;
    public float throwForce = 0.0002f;
    public float maxDragDistance = 5f;
    public float dragMultiplier = 5f;
    public LineRenderer dragLine;
    public Camera gameCamera;

    private Rigidbody2D rb;
    private Vector3 dragStart;
    private Vector3 dragEnd;
    private bool isDragging = false;
    private float dragDistance = 1f;
    private Bounds cameraBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dragLine.enabled = false;

        cameraBounds = new Bounds(gameCamera.transform.position, new Vector3(gameCamera.orthographicSize * gameCamera.aspect * 2, gameCamera.orthographicSize * 2, 0));
    }

    void Update()
    {
        Debug.Log("Pos - " + this.transform.position);
        if (Input.GetMouseButtonDown(0))
        {
            dragStart = transform.position;
            isDragging = true;
            dragDistance = 0f;
            dragLine.enabled = true;
            dragLine.SetPosition(0, dragStart);
            dragLine.SetPosition(1, dragStart);
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            // Clamp the mouse position to the bounds of the camera
            Vector3 clampedMousePosition = cameraBounds.ClosestPoint(mousePosition);
            
            dragDistance = Mathf.Min(Vector3.Distance(clampedMousePosition, dragStart), maxDragDistance);
            dragEnd = dragStart + (clampedMousePosition - dragStart).normalized * dragDistance;
            dragLine.SetPosition(1, dragEnd);
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            GameObject throwObj = Instantiate(throwObject, transform.position, Quaternion.identity);
            Rigidbody2D throwRb = throwObj.GetComponent<Rigidbody2D>();
            Vector3 throwDirection = (dragEnd - dragStart).normalized;
            throwRb.AddForce(throwDirection * dragDistance * dragMultiplier, ForceMode2D.Impulse);
            rb.AddForce(-throwDirection * dragDistance * dragMultiplier, ForceMode2D.Impulse);
            dragLine.enabled = false;
            
            // Check if astronaut is outside camera bounds and move it back inside if necessary
            Vector3 clampedPosition = cameraBounds.ClosestPoint(transform.position);
            if (transform.position != clampedPosition)
            {
                transform.position = clampedPosition;
                rb.velocity = Vector2.zero;
            }
        }
    }
}
