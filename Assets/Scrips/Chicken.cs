using UnityEngine;

public class Chicken : MonoBehaviour
{
    public ChickenSpawner spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInventory>().AddChicken();

            spawner.StartRespawn();  // spawn sürecini başlat
            Destroy(gameObject);     // tavuğu yok et
        }
    }
}