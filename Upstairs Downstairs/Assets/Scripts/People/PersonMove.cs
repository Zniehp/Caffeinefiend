using UnityEngine;
using UnityEngine.Events;
public class PersonMove : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    public Vector3 personWaitingPoint;
    private bool waitingAtKing;
    private CardWaitForPerson cardwaitforpersonscript;

    private void Update()
    {
        if (waitingAtKing == false)
        {
            float step = movementSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, personWaitingPoint, step);
            float distanceToWaitingSpot = Vector3.Distance(personWaitingPoint, gameObject.transform.position);
            if (distanceToWaitingSpot <= 0.1f)
            {
                waitingAtKing = true;
                EnableCard();
            }
        }
    }
    
    private void EnableCard()
    {
        Debug.Log("waitingAtKing");
        GameObject obj = GameObject.Find("Canvas");
        cardwaitforpersonscript = obj.GetComponent<CardWaitForPerson>();
        cardwaitforpersonscript.EnableCard();
    }
}
