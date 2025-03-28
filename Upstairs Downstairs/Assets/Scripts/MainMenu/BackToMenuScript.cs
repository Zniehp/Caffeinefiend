using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuScript : MonoBehaviour
{
    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
