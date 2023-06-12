using UnityEngine;

public class ColliderInteract : MonoBehaviour {
    public string layerName = "InteractLayer";

    private Rigidbody2D _rb;
    private Vector3 _initialPosition;

    public void ResetObject() {
        _rb.constraints = RigidbodyConstraints2D.FreezePosition;
        transform.position = _initialPosition;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        SoundManager.instance.PlayEffect3(5);


    }

    private void Start() {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _initialPosition = transform.position;
        int targetLayer = LayerMask.NameToLayer(layerName);

        if (targetLayer != -1) {
            // Set collision matrix to only interact with the target layer
            for (int i = 0; i < 32; i++) {
                if (i != targetLayer) {
                    Physics2D.IgnoreLayerCollision(gameObject.layer, i);
                }
            }
        }
        else {
            Debug.LogError("Layer '" + layerName + "' does not exist!");
        }
    }



}