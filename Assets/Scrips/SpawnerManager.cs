using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public PlayerInventory player;
    public ChickenSpawner[] spawners;
    public int unlockCost = 50;

    private int unlockedCount = 1;

    public void BuySpawner()
    {
        if (player.money >= unlockCost && unlockedCount < spawners.Length)
        {
            player.money -= unlockCost;

            spawners[unlockedCount].gameObject.SetActive(true);
            unlockedCount++;
        }
    }
}