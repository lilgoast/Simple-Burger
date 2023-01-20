using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject healthUI;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject correctIngredientImage;
    [SerializeField] GameObject losePanel;
    [SerializeField] int startHealthAmount = 3;

    public static int healthAmount;

    public static bool levelComplete;
    public static bool levelFailed;

    private int tempHealth;
    private static GameObject checkmark;

    private void Awake()
    {
        Init();
    }

    private void FixedUpdate()
    {
        if (tempHealth != healthAmount)
        {
            ChangeHealth();
            tempHealth = healthAmount;
        }
        if (levelComplete && !levelFailed)
        {
            winPanel.SetActive(true);
        }
    }

    private void Init()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        levelComplete = false;
        levelFailed = false;
        healthAmount = startHealthAmount;
        tempHealth = healthAmount;
        checkmark = correctIngredientImage;
        InitHearts();
    }

    private void ChangeHealth()
    {
        if(healthAmount < 0)
        {
            levelFailed = true;
            losePanel.SetActive(true);
            Time.timeScale = 0.01f;
        }
        else
        {
            healthUI.transform.GetChild(healthAmount).gameObject.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void SpawnCorrectIngredientImage()
    {
        Instantiate(checkmark, checkmark.transform.parent).SetActive(true);
    }

    private void InitHearts()
    {
        for (int i = 1; i < healthAmount; i++)
        {
            Instantiate(healthUI.transform.GetChild(0), healthUI.transform).GetComponent<RectTransform>().anchoredPosition -= new Vector2(i * 200f, 0f);
        }
    }

}
