using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredients : MonoBehaviour
{
    [SerializeField] GameObject ingridients;
    [SerializeField] float timeBetweenSpawn = 1f;

    public static int currentAnountOfIngridients;

    private List<GameObject> ingridientsObjects = new();
    private int ingridientsAmount;
    private float timePassed;

    void Start()
    {
        timePassed = timeBetweenSpawn;
        ReadIngridients();
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= timeBetweenSpawn)
        {
            SpawnIngridient();
            timePassed = 0f;
        }
    }

    private void ReadIngridients()
    {
        ingridientsAmount = ingridients.transform.childCount;
        for (int i = 0; i < ingridientsAmount; i++)
        {
            ingridientsObjects.Add(ingridients.transform.GetChild(i).gameObject);
        }
    }

    private void SpawnIngridient()
    {

        int randomNum = Random.Range(0, ingridientsAmount);
        Vector3 position = transform.position + new Vector3(15f, 3f, 0f);

        Instantiate(ingridientsObjects[randomNum], position, transform.rotation);

        currentAnountOfIngridients++;
    }
}
