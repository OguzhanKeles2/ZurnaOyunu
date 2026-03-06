using UnityEngine;
using System.Collections;

public class ChickenSpawner : MonoBehaviour
{
    public GameObject chickenPrefab;
    public float respawnTime = 5f;

    private bool isRespawning = false;

    void Start()
    {
        SpawnChicken();
    }

    void SpawnChicken()
    {
        GameObject newChicken = Instantiate(chickenPrefab, transform.position, Quaternion.identity);

        Chicken chickenScript = newChicken.GetComponent<Chicken>();
        chickenScript.spawner = this;
    }

    public void StartRespawn()
    {
        if (!isRespawning)
            StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        isRespawning = true;

        yield return new WaitForSeconds(respawnTime);

        SpawnChicken();

        isRespawning = false;
    }
}