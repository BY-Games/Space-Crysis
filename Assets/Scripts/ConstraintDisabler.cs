using UnityEngine;

public class ConstraintDisabler : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float detachDelayTime = 5f;
    public ParticleSystem boomParticles;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(DisableConstraints), detachDelayTime); // Invoke the method after 5 seconds
    }

    private void DisableConstraints()
    {
        if (boomParticles != null) {
            boomParticles.gameObject.SetActive(true);
            boomParticles.Play();
            Debug.Log("Played");
        }
            
        _rb.constraints = RigidbodyConstraints2D.None; // Disable all constraints
    }
}


// using UnityEngine;
//
// public class ConstraintDisabler : MonoBehaviour
// {
//     public float shakeDuration = 0.5f;
//     public float shakeMagnitude = 0.1f;
//     public ParticleSystem boomParticles;
//
//     private Rigidbody2D rb;
//     private Vector2 initialPosition;
//     private bool hasShaken = false;
//
//     private void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         initialPosition = transform.position;
//         Invoke("DisableConstraints", shakeDuration);
//     }
//
//     private void Update()
//     {
//         if (!hasShaken && Time.time < shakeDuration)
//         {
//             // Calculate the shake offset based on time
//             float shakeOffsetX = Random.Range(-shakeMagnitude, shakeMagnitude);
//             float shakeOffsetY = Random.Range(-shakeMagnitude, shakeMagnitude);
//
//             // Apply the shake offset to the game object's position
//             transform.position = initialPosition + new Vector2(shakeOffsetX, shakeOffsetY);
//         }
//         else if (!hasShaken && Time.time >= shakeDuration)
//         {
//             // Activate boom particles and mark as shaken
//             if (boomParticles != null)
//                 boomParticles.Play();
//
//             hasShaken = true;
//         }
//     }
//
//     private void DisableConstraints()
//     {
//         rb.constraints = RigidbodyConstraints2D.None;
//         transform.position = initialPosition; // Reset the position after shaking
//     }
// }








// using UnityEngine;
//
// public class ConstraintDisabler : MonoBehaviour
// {
//     public float shakeDuration = 5f;
//     public float shakeMagnitude = 0.1f;
//
//     private Rigidbody2D rb;
//     private Vector2 initialPosition;
//
//     private void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         initialPosition = transform.position;
//         Invoke("DisableConstraints", shakeDuration);
//     }
//
//     private void Update()
//     {
//         if (Time.time < shakeDuration)
//         {
//             // Calculate the shake offset based on time
//             float shakeOffsetX = Random.Range(-shakeMagnitude, shakeMagnitude);
//             float shakeOffsetY = Random.Range(-shakeMagnitude, shakeMagnitude);
//
//             // Apply the shake offset to the game object's position
//             transform.position = initialPosition + new Vector2(shakeOffsetX, shakeOffsetY);
//         }
//     }
//
//     private void DisableConstraints()
//     {
//         rb.constraints = RigidbodyConstraints2D.None;
//         transform.position = initialPosition; // Reset the position after shaking
//     }
// }
