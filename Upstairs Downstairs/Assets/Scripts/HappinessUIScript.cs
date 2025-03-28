using UnityEngine;
using TMPro;
using System.Resources;

public class HappinessUIScript : MonoBehaviour
{
    public TMP_Text textComponent;
    public ResourceManager resourceManager;

    public void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
        resourceManager = GetComponent<ResourceManager>();
    }
    private void Update()
    {
        textComponent.text = $"Happiness: {resourceManager.happiness}";
    }
}