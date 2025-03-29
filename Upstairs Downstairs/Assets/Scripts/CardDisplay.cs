using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Events;
public class CardDisplay : MonoBehaviour
{
    public static CardDisplay Instance;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public RectTransform cardRectTransform;

    public CardData[] availableCards;
    private CardData currentCard;
    public CardData zerocard;

    private Vector2 touchStartPos;
    private float swipeThreshold = 100f;
    private float swipeSpeed = 5f;

    private int currentCardIndex;

    public PersonSpawner personSpawner;

    [SerializeField]
    private int bobcards;
    [SerializeField]
    private int farmercards;
    [SerializeField]
    private int peasantcards;
    [SerializeField]
    private int robincapecards;
    [SerializeField]
    private int tradercards;

    public CardData firstButlerCard;
    public CardData secondButlerCard;

    void Awake()
    {
        Instance = this;
        currentCard = firstButlerCard;
        UpdateCard();
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

        ApplyEffect(accepted);

        MakePersonMove();
    }


    private void ApplyEffect(bool accepted)
    {
        currentCard.ApplyEffect(accepted);

        currentCard = zerocard;
    }

    public void DrawCard()
    {
        RandomCard();
        if (availableCards.Length > 0)
        {
            currentCard = availableCards[currentCardIndex];
            titleText.text = currentCard.title;
            descriptionText.text = currentCard.description;

            cardRectTransform.position = new Vector3(0, 0, 0);
        }
    }

    //moving person towards evil king
    void MakePersonMove()
    {
        PersonMove personmove = FindAnyObjectByType<PersonMove>();
        personmove.waitingAtKing = false;
        personmove.DecideWhereToGo();
        Debug.Log("moving back");
        personmove.DisableCard();
    }

    void RandomCard()
    {
       currentCardIndex = Random.Range(0, availableCards.Length);
        if (currentCardIndex <= bobcards)
        {
            Debug.Log("picked bob");
            personSpawner.SpawnBob();
        }
        else if (currentCardIndex <= farmercards)
        {
            Debug.Log("farmercards");
            personSpawner.SpawnFarmer();
        }
        else if (currentCardIndex <= peasantcards)
        {
            Debug.Log("picked peasant");
            personSpawner.SpawnPeasant();
        }
        else if (currentCardIndex <= robincapecards)
        {
            Debug.Log("picked RobinCape");
            personSpawner.SpawnRobinCape();
        }
        else if (currentCardIndex <= tradercards)
        {
            Debug.Log("picked trader");
            personSpawner.SpawnTrader();
        }
    }

    public void ChangeCardToSecondButler()
    {
        currentCard = secondButlerCard;
        UpdateCard();
    }

    public void UpdateCard()
    {
        titleText.text = currentCard.title;
        descriptionText.text = currentCard.description;

        cardRectTransform.position = new Vector3(0, 0, 0);
    }
}

