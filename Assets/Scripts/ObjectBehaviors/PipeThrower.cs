
using UnityEngine;
using UnityEngine.Serialization;

public class PipeThrower : MonoBehaviour
{
    public float throwForce = 3f;
    [SerializeReference] bool straight = true;
    public PipeType type;
    [SerializeReference] private bool firstEntrance;

    [FormerlySerializedAs("ExitPipe")]
    [SerializeField]
    Transform exitPipe;

    [FormerlySerializedAs("SecondEntrance")]
    [SerializeField]
    private Transform secondEntrance;


    [SerializeField] Transform extendedBendTrasform;


    public void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision was with the astronaut
        if (collision.gameObject.CompareTag("Player"))
        {
            float impactStrength = collision.relativeVelocity.magnitude;
            // Debug.Log("Got Collision");

            // Calculate the throw direction and apply force to the astronaut
            var position = exitPipe.position;
            var entrance = transform.position;
            if (type == PipeType.ExtendedBend)
            {
                if (extendedBendTrasform != null)
                {
                    entrance = extendedBendTrasform.position;

                }
                else
                {
                    Debug.Log("Warning: extendedBendTrasform is not initialized!");
                }
            }


            //    Debug.Log("Position vec" + position);
            Vector2 throwDirection;
            if (firstEntrance)
            {
                throwDirection = entrance - secondEntrance.position; // use the pipe's right direction
            }
            else
            {
                throwDirection = secondEntrance.position - entrance; // use the pipe's right direction
            }

            //  Debug.Log("Throw vec " + throwDirection);

            //Debug.Log("Before change pos" + collision.gameObject.transform.position);
            collision.gameObject.transform.position = position; // Teleport to other side of pipe
            //Debug.Log("Before AFTER pos" + collision.gameObject.transform.position);
            if (type == PipeType.Bend)
            {
                throwDirection = Vector2.Perpendicular(throwDirection);
            }


            //Debug.Log("Direction Vector " + throwDirection);

            // Force applied on player when exit the pipe
            Vector3 exitPipeForce = throwDirection * throwForce * impactStrength;
            // Debug.Log("Direction Vector " + exitPipeForce);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(exitPipeForce, ForceMode2D.Impulse);
        }
    }


    public enum PipeType
    {
        Straight,
        Bend,
        ExtendedBend
    }
}