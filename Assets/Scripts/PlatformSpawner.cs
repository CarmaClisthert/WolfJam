using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public Transform player;
    public float spawnHeight = 15f;
    public float minX = -5f, maxX = 5f;

    private float nextSpawnY = 0f;
    public NPCSpawner npcSpawner;

    void Update()
    {
        if (player.position.y + spawnHeight > nextSpawnY)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(minX, maxX),
            nextSpawnY,
            0
        );

        GameObject spawnedPlatform = Instantiate(
            platformPrefabs[Random.Range(0, platformPrefabs.Length)],
            spawnPosition,
            Quaternion.identity
        );

        // Force NPC spawn for testing
        if (npcSpawner != null)
        {
            npcSpawner.SpawnNPC(spawnedPlatform);
        }

        nextSpawnY += Random.Range(2f, 4f);
    }




    /* OG DO NOT DELETE
    void SpawnPlatform()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(minX, maxX),
            nextSpawnY,
            0
        );

        Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], spawnPosition, Quaternion.identity);
        nextSpawnY += Random.Range(2f, 4f); // Adjust gap between platforms
    } */
}
