using UnityEngine;

[CreateAssetMenu(fileName = "NewCardData", menuName = "Card System/EvilCardData")]
public class EvilCardData : ScriptableObject
{
    public string title;
    public string description;
    
    public int cardNumber;

    public int goldChangeIfYes;
    public int happinessChangeIfYes;
    public int goldChangeIfNo;
    public int happinessChangeIfNo;

    public void EvilApplyEffect(bool accepted)
    {
        if (accepted)
        {
            ResourceManager.Instance.ChangeResources(goldChangeIfYes, happinessChangeIfYes);
        }
        else
        {
            ResourceManager.Instance.ChangeResources(goldChangeIfNo, happinessChangeIfNo);
        }
    }
}