using UnityEngine;

public class GameOverMenuScript : MonoBehaviour
{
    public GameObject losePanel;

    public void OnLoseGame()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

    public void Awake()
    {
        Time.timeScale = 1;
    }
}
