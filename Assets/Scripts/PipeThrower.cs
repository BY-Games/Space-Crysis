using UnityEngine;

public class PipeThrower : MonoBehaviour
{
    public float throwForce = 3f;
    [SerializeField] Transform ExitPipe;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision was with the astronaut
        if (collision.gameObject.CompareTag("Player"))
        {
            float impactStrength = collision.relativeVelocity.magnitude;
            // Calculate the throw direction and apply force to the astronaut
            Debug.Log("Got Collision");
            Vector2 throwDirection = ExitPipe.position - transform.position; // use the pipe's right direction
            collision.gameObject.transform.position = ExitPipe.position; // Teleport to other side of pipe
            Debug.Log("Direction Vector " + throwDirection);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(throwDirection * impactStrength * throwForce, ForceMode2D.Impulse);
        }
    }   
}
