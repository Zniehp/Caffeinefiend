using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using System.Collections;
using System.Runtime.CompilerServices;
public class PersonMove : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    public Vector3 personWaitingPoint;
    public bool waitingAtKing;
    private CardWaitForPerson cardwaitforpersonscript;
    public Transform[] pointsToEvilKing;
    private int destinationPoint;
    private NavMeshAgent agent;
    private Transform targetPosition;
    private float distanceToWaitingSpot;
    private int currentpointindex;
    public float tickrate;
    private CardDisplay carddisplay;
    public Vector3 offScreen;
    private bool isOffScreen;
    private PersonSpawner personSpawner;

    private void Start()
    {
        carddisplay = FindAnyObjectByType<CardDisplay>();
        waitingAtKing = false;
        currentpointindex = 0;
        StartCoroutine(MoveTowardsKing());
        GameObject obj = GameObject.Find("Canvas");
        cardwaitforpersonscript = obj.GetComponent<CardWaitForPerson>();
        personSpawner = FindAnyObjectByType<PersonSpawner>();
        isOffScreen = false;
    }
    private IEnumerator MoveTowardsKing()
    {
        while (waitingAtKing == false)
        {
            float step = movementSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, personWaitingPoint, step);
            float distanceToWaitingSpot = Vector3.Distance(personWaitingPoint, gameObject.transform.position);
            if (distanceToWaitingSpot <= 0.1f)
            {
                waitingAtKing = true;
                EnableCard();
                yield return null;
            }
            yield return new WaitForSeconds(1 / tickrate);
        }
    }

    public void EnableCard()
    {
        Debug.Log("waitingAtKing");
        cardwaitforpersonscript.EnableCard();
    }
    public void DisableCard()
    {
        cardwaitforpersonscript.DisableCard();
    }

    //move to evil king part of script

    public void StartTowardsEvilKing()
    {
        StartCoroutine(MoveToEvilKing());
    }
    public IEnumerator MoveToEvilKing()
    {
        while (waitingAtKing == false)
        {
            float step = movementSpeed * Time.deltaTime;

            targetPosition = pointsToEvilKing[currentpointindex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, step);
            float distanceToWaitingSpot = Vector3.Distance(targetPosition.position, gameObject.transform.position);
            if (distanceToWaitingSpot <= 0.1f)
            {
                currentpointindex += 1;
                if (currentpointindex == 3)
                {
                    waitingAtKing = true;
                    EnableEvilCard();
                    carddisplay.DrawCard();
                    yield return null;
                }
            }
            yield return new WaitForSeconds(1 / tickrate);
        }
    }
    public void EnableEvilCard()
    {
        Debug.Log("waitingAtKing");
        GameObject obj = GameObject.Find("Canvas");
        cardwaitforpersonscript = obj.GetComponent<CardWaitForPerson>();
        cardwaitforpersonscript.EnableCard();
    }

    public void StartGoBackFromKing()
    {
        StartCoroutine(GoBackFromKing());
    }
    private IEnumerator GoBackFromKing()
    {
        while (isOffScreen == false)
        {
            float step = movementSpeed * Time.deltaTime;

            
            transform.position = Vector3.MoveTowards(transform.position, offScreen, step);
            float distanceToWaitingSpot = Vector3.Distance(offScreen, gameObject.transform.position);
            if (distanceToWaitingSpot <= 0.1f)
            {
                isOffScreen = true;
                RandomPersonScript personscript = GetComponent<RandomPersonScript>();

                if (personscript != null)
                {
                    personSpawner.SpawnRandomPerson();
                }
                else
                {
                    personSpawner.SpawnSecondButler();
                }

                Destroy(gameObject);
                yield return null;
            }
            yield return new WaitForSeconds(1 / tickrate);
        }
    }
}


