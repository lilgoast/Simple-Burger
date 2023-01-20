using UnityEngine;

public class ConveyorMoving : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    private Rigidbody rigidBody;
    private Renderer myRenderer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        myRenderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        Vector3 currentPos = rigidBody.position;
        rigidBody.position += speed * Time.fixedDeltaTime * Vector3.right;
        rigidBody.MovePosition(currentPos);
    }
}
