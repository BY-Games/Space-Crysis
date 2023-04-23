using UnityEngine;

public class DragAndThrow : MonoBehaviour {

    public GameObject astronaut;
    public GameObject projectile;
    public float dragSpeed = 10f;

    private Vector2 mouseDownPos;
    private bool isDragging;
    private Vector3 startPos;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    public void Start() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    public void Update() {
        // Check if the left mouse button is down
        if (Input.GetMouseButtonDown(0)) {
            // Get the mouse position
            mouseDownPos = Input.mousePosition;
            startPos = astronaut.transform.position;
            isDragging = true;
        }

        // Check if the left mouse button is up
        if (Input.GetMouseButtonUp(0)) {
            // If the left mouse button is up, stop dragging
            isDragging = false;
        }

        // If the left mouse button is down and we are dragging, move the object
        if (isDragging) {
            // Get the current mouse position
            Vector2 currentMousePos = Input.mousePosition;

            // Calculate the difference between the current mouse position and the mouse down position
            Vector2 deltaPos = currentMousePos - mouseDownPos;

            // Move the object by the delta position
             astronaut.transform.position += (Vector3)deltaPos * dragSpeed;

            // Update the position of the line renderer
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, astronaut.transform.position);
        }
    }

    // Start dragging
    private void OnMouseDown() {
        isDragging = true;
    }

    // Stop dragging
    private void OnMouseUp() {
        isDragging = false;
    }
}
