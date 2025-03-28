using UnityEngine;
using TMPro;

public class WealthUIScript : MonoBehaviour
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
        textComponent.text = $"Wealth: {resourceManager.gold}";
    }
}
