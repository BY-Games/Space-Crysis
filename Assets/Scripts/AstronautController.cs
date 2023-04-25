using System.Collections;
using UnityEngine;

public class AstronautController : MonoBehaviour
{
    public GameObject throwObject;
    public float throwForce = 10f;
    public float maxDragDistance = 5f;
    public float dragMultiplier = 5f;
    public Camera gameCamera;
    public float linearDrag = 0.1f;
    public float angularDrag = 0.1f;

    // [SerializeField] Transform centerObject;

    private Rigidbody2D rb;
    private Vector3 dragStart;
    private Vector3 dragEnd;
    private bool isDragging = false;
    private float dragDistance = 0f;
    private Bounds cameraBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = linearDrag;
        rb.angularDrag = angularDrag;
        cameraBounds = new Bounds(gameCamera.transform.position, new Vector3(gameCamera.orthographicSize * gameCamera.aspect * 2, gameCamera.orthographicSize * 2, 0));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStart = gameObject.GetComponent<Collider2D>().bounds.center;
            isDragging = true;
            dragDistance = 0f;
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            // Clamp the mouse position to the bounds of the camera
            Vector3 clampedMousePosition = cameraBounds.ClosestPoint(mousePosition);
            
            dragDistance = Vector3.Distance(clampedMousePosition, dragStart);
            dragEnd = dragStart + (clampedMousePosition - dragStart).normalized * dragDistance;
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            GameObject throwObj = Instantiate(throwObject, transform.position, Quaternion.identity);
            Rigidbody2D throwRb = throwObj.GetComponent<Rigidbody2D>();
            Vector3 throwDirection = (dragEnd - dragStart).normalized;
            throwRb.AddForce(throwDirection * dragDistance * dragMultiplier, ForceMode2D.Impulse);
            rb.AddForce(-throwDirection * dragDistance * dragMultiplier, ForceMode2D.Impulse);
        }
    }
}


















// public class AstronautController : MonoBehaviour
// {
//     public GameObject throwObject;
//     public float throwForce = 10f;
//     public float maxDragDistance = 5f;
//     public float dragMultiplier = 5f;
//     public LineRenderer dragLine;

//     private Rigidbody2D rb;
//     private Vector3 dragStart;
//     private Vector3 dragEnd;
//     private bool isDragging = false;
//     private float dragDistance = 0f;
//     private Bounds worldBounds;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         dragLine.enabled = false;

//         // Get the bounds of the world
//         worldBounds = new Bounds(Vector3.zero, Vector3.one * 100f);
//     }

//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             dragStart = transform.position;
//             isDragging = true;
//             dragDistance = 0f;
//             dragLine.enabled = true;
//             dragLine.SetPosition(0, dragStart);
//             dragLine.SetPosition(1, dragStart);
//         }
//         else if (Input.GetMouseButton(0) && isDragging)
//         {
//             Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             mousePosition.z = 0;

//             // Clamp the mouse position to the bounds of the world
//             Vector3 clampedMousePosition = worldBounds.ClosestPoint(mousePosition);

//             dragDistance = Mathf.Min(Vector3.Distance(clampedMousePosition, dragStart), maxDragDistance);
//             dragEnd = dragStart + (clampedMousePosition - dragStart).normalized * dragDistance;
//             dragLine.SetPosition(1, dragEnd);
//         }
//         else if (Input.GetMouseButtonUp(0) && isDragging)
//         {
//             isDragging = false;
//             GameObject throwObj = Instantiate(throwObject, transform.position, Quaternion.identity);
//             Rigidbody2D throwRb = throwObj.GetComponent<Rigidbody2D>();
//             Vector3 throwDirection = (dragEnd - dragStart).normalized;
//             throwRb.AddForce(throwDirection * dragDistance * dragMultiplier, ForceMode2D.Impulse);
//             rb.AddForce(-throwDirection * dragDistance * dragMultiplier, ForceMode2D.Impulse);
//             dragLine.enabled = false;
//         }
//     }
// }
