using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public void GoToMainGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
