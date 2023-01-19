using UnityEngine;

public class PickUpIngridient : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform handIKTarget;
    [SerializeField] Transform headAimTarget;

    public static bool objectPickedUp, objectPlaced;
    
    private Animator animator;
    private Transform toPickUpT;

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
                toPickUpT = raycastHit.transform;
                animator.SetTrigger("PickUpIngredientTrigger");
                objectPickedUp = false;
                objectPlaced = false;
            }
        }

        if (toPickUpT != null && !objectPickedUp && !objectPlaced)
        {
            handIKTarget.position = toPickUpT.position + new Vector3(0f, 2f, 0f);
            headAimTarget.position = toPickUpT.position + Vector3.down;
        }
    }
}
