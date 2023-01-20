using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredients : MonoBehaviour
{
    [SerializeField] GameObject ingredients;
    [SerializeField] float timeBetweenSpawn = 1f;

    public static int currentAnountOfIngredients;

    private List<GameObject> ingredientsObjects = new();
    private int ingredientsAmount;
    private float timePassed;

    void Start()
    {
        timePassed = timeBetweenSpawn;
        InitIngredients();
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= timeBetweenSpawn)
        {
            SpawnIngredient();
            timePassed = 0f;
        }
    }

    private void InitIngredients()
    {
        ingredientsAmount = ingredients.transform.childCount;
        for (int i = 0; i < ingredientsAmount; i++)
        {
            ingredientsObjects.Add(ingredients.transform.GetChild(i).gameObject);
        }
    }

    private void SpawnIngredient()
    {

        int randomNum = Random.Range(0, ingredientsAmount);
        Vector3 position = transform.position + new Vector3(15f, 3f, 0f);

        Instantiate(ingredientsObjects[randomNum], position, transform.rotation);

        currentAnountOfIngredients++;
    }
}
