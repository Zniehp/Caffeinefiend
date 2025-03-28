using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public static CardDisplay Instance;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Button yesButton;
    public Button noButton;

    public CardData[] availableCards;
    private CardData currentCard;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        yesButton.onClick.AddListener(() => ChooseOption(true));
        noButton.onClick.AddListener(() => ChooseOption(false));
        DrawCard();
    }

    public void DrawCard()
    {
        if (availableCards.Length > 0)
        {
            currentCard = availableCards[Random.Range(0, availableCards.Length)];
            titleText.text = currentCard.title;
            descriptionText.text = currentCard.description;
        }
    }

    public void ChooseOption(bool accepted)
    {
        currentCard.ApplyEffect(accepted);
        DrawCard();
    }
}
