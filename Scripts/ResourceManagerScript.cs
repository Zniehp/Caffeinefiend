using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    public int gold = 100;
    public int happiness = 100;

    void Awake()
    {
        Instance = this;
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
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
