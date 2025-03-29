using UnityEngine;

public class CardWaitForPerson : MonoBehaviour
{
    public GameObject kaart;
    public GameObject evilKaart;

    public void EnableCard()
    {
        kaart.SetActive(true);
    }

    public void DisableCard()
    {
        kaart.SetActive(false);
    }
    public void EvilEnableCard() 
    {
        evilKaart.SetActive(true);
    }
        public void EvilDisableCard() 
    {
        evilKaart.SetActive(false);
    }


}
