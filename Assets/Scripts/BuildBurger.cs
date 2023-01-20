using Mono.Cecil.Cil;
using UnityEngine;

public class BuildBurger : MonoBehaviour
{
    [SerializeField] GameObject transparentIngredients;

    private static int ingredientLayer;
    private Transform parent;
    private GameObject nextIngredient;

    private void Awake()
    {
        ingredientLayer = 0;
        parent = gameObject.transform;
        GetNextIngredient();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ingredient") && !PickUpIngredient.objectPlaced)
        {
            if(other.name!= nextIngredient.name + "(Clone)")
            {
                UIHandler.healthAmount -= 1;
            }
            PlaceIngredient(other);
            GetNextIngredient();
        }
    }

    private void GetNextIngredient()
    {
        nextIngredient = Instantiate(transparentIngredients.transform.GetChild(Random.Range(0, transparentIngredients.transform.childCount)), parent, false).gameObject;
        nextIngredient.transform.localPosition = new Vector3(-0.065f + (ingredientLayer * 0.004f), 0.03f + (ingredientLayer * 0.006f), 0.09f + (ingredientLayer * 0.009f));
        nextIngredient.transform.localRotation = Quaternion.Euler(0f, -65f, 110f);
        nextIngredient.transform.localScale = Vector3.Scale(nextIngredient.transform.localScale, new Vector3(.07f, .07f, .07f));
    }

    private void PlaceIngredient(Collider other)
    {
        other.transform.localPosition = new Vector3(-0.065f + (ingredientLayer * 0.004f), 0.03f + (ingredientLayer * 0.006f), 0.09f + (ingredientLayer * 0.009f));
        other.transform.localRotation = Quaternion.Euler(0f, -65f, 110f);

        Instantiate(other, parent, false);
        Destroy(other.gameObject);
        Destroy(nextIngredient); 
        PickUpIngredient.objectPlaced = true;

        ingredientLayer++;
    }
}
