using UnityEngine;

public class Chicken : MonoBehaviour
{
    public ChickenSpawner spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInventory inventory = other.GetComponent<PlayerInventory>();
        if (inventory == null) return;

        inventory.AddChicken();   // parametre kaldırıldı

        if (spawner != null)
        {
            spawner.StartRespawn();
        }

        Destroy(gameObject);   // prefablı sistem kullanıyorsan bu kalmalı
    }
}