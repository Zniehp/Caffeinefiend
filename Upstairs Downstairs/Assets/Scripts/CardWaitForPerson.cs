using UnityEngine;

public class CardWaitForPerson : MonoBehaviour
{
    private GameObject kaart;

    private void Awake()
    {
        kaart = gameObject.transform.Find("Kaart").gameObject;
    }
    public void EnableCard()
    {
        kaart.SetActive(true);
    }

    public void DisableCard()
    {
        kaart.SetActive(false);
    }
}
