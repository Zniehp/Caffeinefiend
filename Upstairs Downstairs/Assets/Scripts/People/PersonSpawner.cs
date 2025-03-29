using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    private int personToSpawnIndex;
    public GameObject firstButler;
    public GameObject secondButler;
    public GameObject bob;
    public GameObject peasant;
    public GameObject farmer;
    public GameObject robincape;
    public GameObject trader;

    private void SpawnFirstButler()
    {
        Instantiate(firstButler, transform.position, Quaternion.identity);
    }

    public void SpawnSecondButler()
    {
        Instantiate(secondButler, transform.position, Quaternion.identity);
    }
    public void SpawnBob()
    {
        Instantiate(bob, transform.position, Quaternion.identity);
    }
    public void SpawnPeasant()
    {
        Instantiate(peasant, transform.position, Quaternion.identity);
    }
    public void SpawnFarmer()
    {
        Instantiate(farmer, transform.position, Quaternion.identity);
    }
    public void SpawnRobinCape()
    {
        Instantiate(robincape, transform.position, Quaternion.identity);
    }
    public void SpawnTrader()
    {
        Instantiate(trader, transform.position, Quaternion.identity);
    }
}
