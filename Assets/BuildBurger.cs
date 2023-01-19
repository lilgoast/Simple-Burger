using UnityEngine;

public class BuildBurger : MonoBehaviour
{
    private static int ingredientLayer;
    private Transform parent;

    private void Awake()
    {
        ingredientLayer = 1;
        parent = gameObject.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ingredient") && !PickUpIngridient.objectPlaced)
        {
            other.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            other.transform.localPosition = new Vector3(-0.06f, 0.06f, 0.02f + (ingredientLayer++ * 0.05f));
            Instantiate(other, parent, false);
            Destroy(other.gameObject);
            PickUpIngridient.objectPlaced = true;
        }
    }
}
