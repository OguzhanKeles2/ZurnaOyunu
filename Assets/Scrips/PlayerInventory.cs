using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public int chickenCount = 0;
    public int pluckedCount = 0;
    public int money = 0;

    public TextMeshProUGUI chickenText;
    public TextMeshProUGUI moneyText;

    public GameObject rawChickenPrefab;
    public GameObject pluckedChickenPrefab;

    public Transform handPoint;
    public Transform pluckSpawnPoint;   // YANDA SPAWN NOKTASI

    public float stackHeight = 0.4f;

    private List<GameObject> stackedChickens = new List<GameObject>();
    private int sideStackCount = 0;     // Yandaki stack sayacı

    void Update()
    {
        if (chickenText != null)
            chickenText.text = "Tavuk: " + chickenCount;

        if (moneyText != null)
            moneyText.text = "Para: " + money;
    }

    public void AddChicken()
    {
        if (pluckedCount > 0) return;

        chickenCount++;

        GameObject newChicken = Instantiate(rawChickenPrefab, handPoint);
        newChicken.transform.localPosition =
            Vector3.up * stackHeight * stackedChickens.Count;
        newChicken.transform.localRotation = Quaternion.identity;

        Rigidbody rb = newChicken.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        stackedChickens.Add(newChicken);
    }

    public void AddPlucked()
    {
        if (chickenCount > 0) return;

        pluckedCount++;

        GameObject newChicken = Instantiate(pluckedChickenPrefab, handPoint);
        newChicken.transform.localPosition =
            Vector3.up * stackHeight * stackedChickens.Count;
        newChicken.transform.localRotation = Quaternion.identity;

        Rigidbody rb = newChicken.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        stackedChickens.Add(newChicken);
    }

    public void PluckAllChickens()
    {
        if (chickenCount <= 0) return;

        int count = chickenCount;

        // Elde duran rawları sil
        foreach (GameObject chicken in stackedChickens)
        {
            Destroy(chicken);
        }

        stackedChickens.Clear();
        chickenCount = 0;

        // YANDA STACKLE
        for (int i = 0; i < count; i++)
        {
            Instantiate(
                pluckedChickenPrefab,
                pluckSpawnPoint.position + Vector3.up * stackHeight * sideStackCount,
                Quaternion.identity
            );

            sideStackCount++;
        }
    }
}