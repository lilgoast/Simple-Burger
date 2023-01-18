using UnityEngine;

public class ConveyorMoving : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 currentPos = rigidBody.position;
        rigidBody.position += speed * Time.fixedDeltaTime * Vector3.right;
        rigidBody.MovePosition(currentPos);
    }
}
