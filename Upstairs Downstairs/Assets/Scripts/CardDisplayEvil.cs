using UnityEngine;
using TMPro;
using System.Collections;

public class EvilCardDisplay : MonoBehaviour
{
    public static EvilCardDisplay Instance;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public RectTransform cardRectTransform;

    public EvilCardData[] evilAvailableCards;
    private EvilCardData currentCard;

    private Vector2 touchStartPos;
    private float swipeThreshold = 100f;
    private float swipeSpeed = 5f;

    void Awake()
    {
        Instance = this;
    }

    public void StartEvilKingSequence()
    {
        EvilDrawCard();
    }

    void Update()
    {
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 touchEndPos = Input.mousePosition;
            if (Vector2.Distance(touchStartPos, touchEndPos) > swipeThreshold)
            {
                if (touchEndPos.x > touchStartPos.x)
                {
                    StartCoroutine(SwipeCard(true)); 
                }
                else
                {
                    StartCoroutine(SwipeCard(false)); 
                }
            }
        }
    }

    private IEnumerator SwipeCard(bool accepted)
        {
        Vector3 targetPosition = accepted ? new Vector3(10, 0, 0) : new Vector3(-10, 0, 0);

        float time = 0f;
        Vector3 startPosition = cardRectTransform.position;

        while (time < 1f)
        {
            cardRectTransform.position = Vector3.Lerp(startPosition, targetPosition, time);
            time += Time.deltaTime * swipeSpeed;

            yield return null;
        }

        cardRectTransform.position = targetPosition;
        PersonMove personmove = FindAnyObjectByType<PersonMove>();
        personmove.DisableEvilCard();
        CardDisplay.Instance.DrawCard();
    }

    private void EvilDrawCard()
    {
        if (evilAvailableCards.Length > 0)
        {
            currentCard = evilAvailableCards[Random.Range(0, evilAvailableCards.Length)];
            titleText.text = currentCard.title;
            descriptionText.text = currentCard.description;

            cardRectTransform.anchoredPosition = new Vector3(0, 0, 0);
        }
    }
}
