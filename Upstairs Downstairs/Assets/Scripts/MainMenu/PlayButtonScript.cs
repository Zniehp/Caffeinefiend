using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public float Duration;
    SpriteRenderer fadeblock;

    private void Awake()
    {
        GameObject fadeblockk = GameObject.Find("FadeBlock");
        fadeblock = fadeblockk.GetComponent<SpriteRenderer>();
    }
    public void GoToMainGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
