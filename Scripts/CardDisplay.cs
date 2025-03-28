using UnityEngine;
using TMPro;
using System.Collections;

public class CardDisplay : MonoBehaviour
{
    public static CardDisplay Instance;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public RectTransform cardRectTransform;

    public CardData[] availableCards;
    private CardData currentCard;

    private Vector2 touchStartPos;
    private float swipeThreshold = 100f; 
    private float swipeSpeed = 5f; 

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        DrawCard(); 
    }

    void Update()
    {
        DetectSwipe(); 
    }

    private void DetectSwipe()
    {
        if (Input.touchCount > 0)  
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 touchEndPos = touch.position;
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
        else if (Input.GetMouseButtonDown(0)) 
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
        Vector3 targetPosition = accepted ? new Vector3(1500, 319, 0) : new Vector3(-1500, 319, 0);

        float time = 0f;
        Vector3 startPosition = cardRectTransform.position;

        while (time < 1f)
        {
        cardRectTransform.position = Vector3.Lerp(startPosition, targetPosition, time);
        time += Time.deltaTime * swipeSpeed; 

        yield return null;
        }

        cardRectTransform.position = targetPosition;

        ApplyEffect(accepted);

        DrawCard();
}


    private void ApplyEffect(bool accepted)
    {
        currentCard.ApplyEffect(accepted);
    }

    public void DrawCard()
    {
        if (availableCards.Length > 0)
        {
            currentCard = availableCards[Random.Range(0, availableCards.Length)];
            titleText.text = currentCard.title;
            descriptionText.text = currentCard.description;

            cardRectTransform.position = new Vector3(513, 319, 0);
        }
    }
}
