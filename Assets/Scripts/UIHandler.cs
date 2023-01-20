using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject healthUI;
    [SerializeField] int startHealthAmount = 3;

    public static int healthAmount;

    private int tempHealth;

    private void Awake()
    {
        healthAmount = startHealthAmount;
        tempHealth = healthAmount;
        InitHearts();
    }

    private void Update()
    {
        if(tempHealth != healthAmount)
        {
            ChangeHealth();
            tempHealth = healthAmount;
        }
    }

    public void ChangeHealth()
    {
        if(healthAmount < 1)
        {
            Debug.Log("You Lose");
        }
        else
        {
            healthUI.transform.GetChild(healthAmount).gameObject.SetActive(false);
        }
    }
    private void InitHearts()
    {
        for (int i = 1; i < healthAmount; i++)
        {
            Instantiate(healthUI.transform.GetChild(0), healthUI.transform).GetComponent<RectTransform>().anchoredPosition -= new Vector2(i * 200f, 0f);
        }
    }
}
