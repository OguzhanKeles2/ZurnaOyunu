using UnityEngine;
using System.Collections;

public class PluckStation : MonoBehaviour
{
    public float waitTime = 3f;
    public GameObject areaEffect;

    private Coroutine currentCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (areaEffect != null)
                areaEffect.SetActive(true);

            currentCoroutine = StartCoroutine(Process(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (areaEffect != null)
                areaEffect.SetActive(false);

            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
                currentCoroutine = null;
            }
        }
    }

    IEnumerator Process(Collider playerCol)
    {
        yield return new WaitForSeconds(waitTime);

        PlayerInventory inv = playerCol.GetComponent<PlayerInventory>();
        if (inv != null)
        {
            inv.PluckAllChickens();
        }

        currentCoroutine = null;
    }
}