using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;

public class BuildBurger : MonoBehaviour
{
    [SerializeField] GameObject transparentIngredients;

    private static int ingredientLayer;
    private Transform parent;
    private GameObject nextIngredient;
    private List<int> ingredientsList = new();
    private int tempIngredientNum = 0;
    private int amountOfIngredients;

    private void Awake()
    {
        Init();
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

    private void Init()
    {
        ingredientLayer = 0;
        parent = gameObject.transform;
        amountOfIngredients = Random.Range(5, 20);

        for (int i = 0; i < amountOfIngredients; i++)
        {
            if (i == 0)
                ingredientsList.Add(0);
            else if(i == amountOfIngredients - 1)
                ingredientsList.Add(0);
            else
                ingredientsList.Add(Random.Range(0, transparentIngredients.transform.childCount - 1));
        }
    }

    private void GetNextIngredient()
    {
        if(tempIngredientNum < amountOfIngredients)
        {
            nextIngredient = Instantiate(transparentIngredients.transform.GetChild(ingredientsList[tempIngredientNum++]), parent, false).gameObject;
            nextIngredient.transform.localPosition = new Vector3(-0.065f + (ingredientLayer * 0.004f), 0.03f + (ingredientLayer * 0.006f), 0.09f + (ingredientLayer * 0.009f));
            nextIngredient.transform.localRotation = Quaternion.Euler(0f, -65f, 110f);
            nextIngredient.transform.localScale = Vector3.Scale(nextIngredient.transform.localScale, new Vector3(.07f, .07f, .07f));
        }
        else
        {
            Debug.Log("You Win!");
        }
        
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
