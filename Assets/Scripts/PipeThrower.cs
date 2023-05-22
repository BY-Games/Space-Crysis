using UnityEngine;

public class PipeThrower : MonoBehaviour
{
    public float throwForce = 3f;
    [SerializeReference] bool straight = true;
    [SerializeField] Transform ExitPipe;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision was with the astronaut
        if (collision.gameObject.CompareTag("Player"))
        {
            float impactStrength = collision.relativeVelocity.magnitude;
            // Debug.Log("Got Collision");

            // Calculate the throw direction and apply force to the astronaut
            var position = ExitPipe.position;
            Vector2 throwDirection;
            Debug.Log("Position vec" + position);
            if (straight) {
                throwDirection = position - transform.position; // use the pipe's right direction
            }
            else {
                throwDirection = position; // use the pipe's right direction
                throwDirection.x *= -1;
                Debug.Log("Throw vec " + throwDirection);
            }
            Debug.Log("Before change pos" + collision.gameObject.transform.position);
            collision.gameObject.transform.position = position; // Teleport to other side of pipe
            // collision.gameObject.transform.position.x *= -1;
            Debug.Log("Before AFTER pos" + collision.gameObject.transform.position);

            // Debug.Log("Direction Vector " + throwDirection);
            
            // Force applied on player when exit the pipe
            Vector3 exitPipeForce = throwDirection;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(exitPipeForce, ForceMode2D.Impulse);
        }
    }   
}
