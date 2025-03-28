using UnityEngine;

public class CardWaitForPerson : MonoBehaviour
{
    public void EnableCard()
    {
        GameObject childByName = gameObject.transform.Find("Kaart").gameObject;
        childByName.SetActive(true);
    }
}
