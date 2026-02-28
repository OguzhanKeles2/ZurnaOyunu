using UnityEngine;
using System.Collections;

public class ChickenSpawner : MonoBehaviour
{
    public GameObject chickenPrefab;
    public float respawnTime = 5f;

    void Start()
    {
        SpawnChicken();
    }

    void SpawnChicken()
    {
        GameObject newChicken = Instantiate(chickenPrefab, transform.position, Quaternion.identity);
        newChicken.GetComponent<Chicken>().spawner = this;
    }

    public void StartRespawn()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnChicken();
    }
}