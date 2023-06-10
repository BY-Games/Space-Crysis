using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BlackHoleEffect : MonoBehaviour {
    [SerializeField] private CircleCollider2D pointEffectorCollider2D;
    [SerializeField] [Tooltip("Best values to set is between 0.1f-0.5f")]
    private float growthScale = 0.1f;
    public float shrinkSpeed = 1f; // Speed at which the objects shrink
    public float rotateSpeed = 10f; // Speed at which the objects rotate
    
    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Eliminated);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log("OnTrigger with -> " + other.tag);
        // Shrink the object
        Vector3 newScale = other.transform.localScale - Vector3.one * shrinkSpeed * Time.fixedDeltaTime;
        other.transform.localScale = newScale;

        // Calculate the direction from the black hole to the object
        Vector3 directionToBlackHole = transform.position - other.transform.position;

        // Calculate the rotation axis perpendicular to the direction
        // Vector3 rotationAxis = Vector3.Cross(directionToBlackHole.normalized, Vector3.up);

        // Rotate the object around the rotation axis
        other.transform.Rotate(0, 0, rotateSpeed * Time.fixedDeltaTime);

        // Check if the object has shrunk to a small enough size
        if (newScale.x <= 0.1f) {
            // Disable the object
            other.gameObject.SetActive(false);
            GetComponentInParent<Transform>().parent.localScale += Vector3.one * 0.05f;

            if (pointEffectorCollider2D != null) {
                pointEffectorCollider2D.radius += growthScale;
            }
        }
    }
}