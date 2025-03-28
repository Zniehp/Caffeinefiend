using UnityEngine;

[CreateAssetMenu(fileName = "NewCardData", menuName = "Card System/CardData")]
public class CardData : ScriptableObject
{
    public string title;
    public string description;

    public int goldChangeIfYes;
    public int happinessChangeIfYes;
    public int goldChangeIfNo;
    public int happinessChangeIfNo;

    public void ApplyEffect(bool accepted)
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
