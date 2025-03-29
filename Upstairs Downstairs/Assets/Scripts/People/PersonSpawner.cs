using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    public List<GameObject> People;
    private int personToSpawnIndex;
    public GameObject firstButler;
    public GameObject secondButler;

    private void Start()
    {
        // SpawnFirstButler();
        SpawnRandomPerson();
    }


    public void SpawnRandomPerson()
    {
        personToSpawnIndex = Random.Range(0, People.Count);
        GameObject personToSpawn = People[personToSpawnIndex];

        Instantiate(personToSpawn, transform.position, Quaternion.identity);
    }

    private void SpawnFirstButler()
    {
        Instantiate(firstButler, transform.position, Quaternion.identity);
    }

    public void SpawnSecondButler()
    {
        Instantiate(secondButler, transform.position, Quaternion.identity);
    }

}
