using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject healthUI;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject correctIngredientImage;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject winsInARowObj;
    [SerializeField] int startHealthAmount = 3;

    public static int healthAmount;

    public static bool levelComplete;
    public static bool levelFailed;

    private int tempHealth;
    private TextMeshProUGUI winsInARowText;
    private static GameObject checkmark;
    private static bool gameStarted;
    private static int winsInARow = 0;

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
            winsInARowText.text = "Wins in a row:\n" + ++winsInARow;
            winPanel.SetActive(true);
            EndAnimationHandler.StartAnimation();
            levelComplete = false;
        }
    }

    private void Init()
    {
        if(!gameStarted)
        {
            healthUI.SetActive(false);
            winsInARowObj.SetActive(false);
            startPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            healthUI.SetActive(true);
            winsInARowObj.SetActive(true);
        }

        winPanel.SetActive(false);
        losePanel.SetActive(false);


        levelComplete = false;
        levelFailed = false;

        healthAmount = startHealthAmount;
        tempHealth = healthAmount;
        checkmark = correctIngredientImage;

        winsInARowText = winsInARowObj.GetComponent<TextMeshProUGUI>();
        winsInARowText.text = "Wins in a row:\n" + winsInARow;
        InitHearts();
    }

    private void ChangeHealth()
    {
        if(healthAmount < 0)
        {
            levelFailed = true;
            winsInARow = 0;
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

    public void StartGame()
    {
        startPanel.SetActive(false);
        healthUI.SetActive(true);
        winsInARowObj.SetActive(true);
        gameStarted = true;
        Time.timeScale = 1f;
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
