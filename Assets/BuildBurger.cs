using UnityEngine;

public class BuildBurger : MonoBehaviour
{
    private static int ingredientLayer;
    private Transform parent;

    private void Awake()
    {
        ingredientLayer = 0;
        parent = gameObject.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ingredient") && !PickUpIngridient.objectPlaced)
        {
            other.transform.localPosition = new Vector3(-0.065f + (ingredientLayer * 0.004f), 0.03f + (ingredientLayer * 0.006f), 0.09f + (ingredientLayer * 0.009f));
            ingredientLayer++;
            other.transform.localRotation = Quaternion.Euler(0f, -65f, 110f);

            Instantiate(other, parent, false);
            Destroy(other.gameObject);
            PickUpIngridient.objectPlaced = true;
        }
    }
}
