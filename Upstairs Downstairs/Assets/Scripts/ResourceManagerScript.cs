using UnityEngine;
using UnityEngine.Events;

public class ResourceManagerScript : MonoBehaviour
{
    public int currentHappiness;

    public int currentWealth;

    public UnityEvent wealthChanged;
    public UnityEvent happinessChanged;

    public void OnWealthChange(int amount)
    {
        currentWealth += amount;
        wealthChanged.Invoke();
    }

    public void OnHappinessChange(int amount)
    {
        currentHappiness += amount;
        happinessChanged.Invoke();
    }
}
