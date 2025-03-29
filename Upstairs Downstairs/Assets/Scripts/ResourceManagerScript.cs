using System.Resources;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text happinessText;
    public static ResourceManager Instance;
    public int gold = 100;
    public int happiness = 100;
    public GameObject canvas;
    public GameObject canvas2;

    void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        GoldDisplay();
        HappinessDisplay();
    }


    public void ChangeResources(int goldChange, int happinessChange)
    {
        gold += goldChange;
        happiness += happinessChange;

        Debug.Log($"Gold: {gold}, Happiness: {happiness}");

        if (gold < 0 || happiness <= 0)
        {
            GameOver();
        }
        GoldDisplay();
        HappinessDisplay();
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        GameOverMenuScript gameOverMenuScript = canvas2.GetComponent<GameOverMenuScript>();
        gameOverMenuScript.OnLoseGame();
    }

    public void GoldDisplay()
    {
        goldText.text = "Wealth: " + gold.ToString();
    }

    public void HappinessDisplay()
    {
        happinessText.text = $"Happiness: {happiness}";
    }
}
