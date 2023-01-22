using UnityEngine;

public class PickUpIngredient : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform handIKTarget;
    [SerializeField] Transform headAimTarget;

    public static bool objectPickedUp, objectPlaced;

    private Animator animator;
    private Transform toPickUpTransform;
    private static bool animationEnded;

    private void Awake()
    {
        animationEnded = true;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        animator.ResetTrigger("PickUpIngredientTrigger");

        if (Input.touchCount > 0 && !UIHandler.levelComplete && !UIHandler.levelFailed && animationEnded && BuildBurger.ingredientPlacingEnded)
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
                animationEnded = false;
                BuildBurger.ingredientPlacingEnded = false;
            }
        }

        if (toPickUpTransform != null && !objectPickedUp)
        {
            MoveHandToIngredient();
        }
    }

    private void MoveHandToIngredient()
    {
        handIKTarget.position = toPickUpTransform.position + new Vector3(0f, 2.5f, 1.2f);
        headAimTarget.position = toPickUpTransform.position + Vector3.down;
    }

    private void SetAnimationEnd()
    {
        animationEnded = true;
    }
}
