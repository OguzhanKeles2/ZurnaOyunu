using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int chickenCount = 0;
    public int money = 0;

    public TextMeshProUGUI chickenText;
    public TextMeshProUGUI moneyText;

    public GameObject chickenPrefab;
    public Transform handPoint;

    private GameObject currentChicken;

    void Update()
    {
        chickenText.text = "Tavuk: " + chickenCount;
        moneyText.text = "Para: " + money;
    }

    public void AddChicken()
    {
        chickenCount++;

        if (currentChicken == null)
        {
            currentChicken = Instantiate(chickenPrefab, handPoint);
            currentChicken.transform.localPosition = Vector3.zero;
            currentChicken.transform.localRotation = Quaternion.identity;

            Rigidbody rb = currentChicken.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
        }
    }
}