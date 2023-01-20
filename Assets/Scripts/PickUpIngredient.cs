using UnityEngine;

public class PickUpIngredient : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform handIKTarget;
    [SerializeField] Transform headAimTarget;

    public static bool objectPickedUp, objectPlaced;

    private Animator animator;
    private Transform toPickUpTransform;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        animator.ResetTrigger("PickUpIngredientTrigger");

        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;

            Ray ray = mainCamera.ScreenPointToRay(pos);

            if (Physics.Raycast(ray, out RaycastHit raycastHit) && raycastHit.collider.CompareTag("Ingredient"))
            {
                toPickUpTransform = raycastHit.transform;
                animator.SetTrigger("PickUpIngredientTrigger");
                objectPickedUp = false;
                objectPlaced = false;
            }
        }

        if (toPickUpTransform != null && !objectPickedUp && !objectPlaced)
        {
            MoveHandToIngredient();
        }
    }

    private void MoveHandToIngredient()
    {
        handIKTarget.position = toPickUpTransform.position + new Vector3(0f, 0f, 1.2f);
        headAimTarget.position = toPickUpTransform.position + Vector3.down;
    }
}
