
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public float npcSpawnProbability = 0.5f;

    public void SpawnNPC(GameObject platform)
    {

        if (Random.value <= npcSpawnProbability)
        {
            // Get the platform's position
            Vector3 platformPosition = platform.transform.position;

            // Calculate the spawn position slightly above the platform
            Vector3 npcSpawnPosition = new Vector3(
                platformPosition.x,
                platformPosition.y + 1f, // Offset NPC above the platform
                platformPosition.z
            );

            // Instantiate the NPC
            Instantiate(npcPrefab, npcSpawnPosition, Quaternion.identity);
        }
    }
}
