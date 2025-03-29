using UnityEngine;

public class FirstButlerScript : MonoBehaviour
{

    private PersonSpawner personSpawner;
    private void Awake()
    {
        PersonSpawner personspawner = FindAnyObjectByType<PersonSpawner>();
    }
    public void SpawnSecondButler()
    {
        personSpawner.SpawnSecondButler();
    }
}
