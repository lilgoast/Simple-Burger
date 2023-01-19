using UnityEngine;

public class PickUpIngridient : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform handIKTarget;

    public static Transform toPickUpT;

    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        animator.ResetTrigger("PickUpIngredientTrigger");

        if (Input.touchCount == 1)
        {
            animator.SetTrigger("PickUpIngredientTrigger");

            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;
            RaycastHit raycastHit;
            Ray ray = mainCamera.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out raycastHit) && raycastHit.collider.CompareTag("Ingredient"))
            {
                toPickUpT = raycastHit.transform;
            }
        }

        if (toPickUpT != null)
        {
            handIKTarget.position = toPickUpT.position + new Vector3(0f, 2f, 0f);
        }
    }
}
