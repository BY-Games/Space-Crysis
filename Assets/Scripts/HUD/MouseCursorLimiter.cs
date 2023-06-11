using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseCursorLimiter : MonoBehaviour {
    public static MouseCursorLimiter Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            // Keep the component alive as long the program is active.
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private Camera gameCamera;
    public int borderBuffer = 10; // Buffer zone size

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private bool isCursorConfined;

    
    private void Start()
    {
        // Calculate the camera's boundaries in screen coordinates
        CalculateCameraBoundaries();

        // Initialize cursor confinement state
        isCursorConfined = false;
        // Find and assign the main camera in the initial scene
        gameCamera = Camera.main;

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find and assign the main camera in the newly loaded scene
        gameCamera = Camera.main;
    }


    private void Update() {
        // Check if the mouse button is pressed down
        if (Input.GetMouseButtonDown(0)) {
            // Enable cursor confinement
            EnableCursorConfined();
        }
        // Check if the mouse button is released
        else if (Input.GetMouseButtonUp(0)) {
            // Disable cursor confinement
            DisableCursorConfined();
        }

        // If the cursor is confined, update its position
        if (isCursorConfined) {
            // Get the mouse position in screen coordinates
            Vector3 mousePosition = Input.mousePosition;

            // Apply buffer zone to the left border
            if (mousePosition.x < minX + borderBuffer) {
                mousePosition.x = minX + borderBuffer;
            }

            // Clamp the mouse position within the camera boundaries
            float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
            float clampedY = Mathf.Clamp(mousePosition.y, minY, maxY);
            Vector3 clampedPosition = new Vector3(clampedX, clampedY, mousePosition.z);

            // Check if the mouse position needs to be updated
            if (clampedPosition != mousePosition) {
                // Move the cursor to the clamped position
                Cursor.visible = false; // Hide the cursor temporarily
                SetCursorPosition(clampedPosition);
                Cursor.visible = true; // Show the cursor again
            }
        }
    }

    private void CalculateCameraBoundaries() {
        // Calculate the camera's boundaries in screen coordinates based on the game window size
        minX = 0;
        maxX = Screen.width;
        minY = 0;
        maxY = Screen.height;
    }

    private void SetCursorPosition(Vector3 position) {
        // Set the cursor position using a Windows API call
        SetCursorPos((int)position.x, (int)position.y);
    }

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);

    private void EnableCursorConfined() {
        // Lock the cursor within the game window
        Cursor.lockState = CursorLockMode.Confined;
        isCursorConfined = true;
    }

    private void DisableCursorConfined() {
        // Release the cursor confinement
        Cursor.lockState = CursorLockMode.None;
        isCursorConfined = false;
    }
}