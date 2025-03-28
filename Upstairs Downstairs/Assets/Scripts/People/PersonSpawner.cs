using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    public List<GameObject> People;
    private int personToSpawnIndex;

    private void Start()
    {
        SpawnPerson();
    }


    private void SpawnPerson()
    {
        personToSpawnIndex = Random.Range(0, People.Count);
        GameObject personToSpawn = People[personToSpawnIndex];

        Instantiate(personToSpawn, transform.position, Quaternion.identity);
    }
}
