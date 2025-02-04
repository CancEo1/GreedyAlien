using System.Collections;
using UnityEngine;

public class ResourceSpawn : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject diamondPrefab;
    public int diamonds;
    private int DiamondsSpawned = 0;
    public int SpawnRadius;
    // private int maxSpawnHeight = 4;
    public Quaternion newRotation = Quaternion.identity;

    [Header("Raycast settings")] // if needed
    public LayerMask groundLayer;
    public float heightOffset = 1f;
    public float maxHeight = 5.0f; // max height of allowed spawn
    public float minHeight = 0.5f;

    [Header("Timer Settings")]
    public float spawnDuration = 60.0f;
    public float spawnInterval = .1f;

    private static ResourceSpawn instance;

    private void Start()
    {
        instance = this;
        StartCoroutine(SpawnDiamondsForTime(60.0f));
    }

    private IEnumerator SpawnDiamondsForTime(float duration)
    {
        float endTime = Time.time + duration;
        while (Time.time < endTime) 
        {
            SpawnDiamonds();
            yield return new WaitUntil(() => DiamondsSpawned == 0);
        }
    }

    private void SpawnDiamonds()
    {
        Vector2 randomCircle = Random.insideUnitCircle * SpawnRadius;
        Vector3 randomPosition = new Vector3(randomCircle.x, heightOffset, randomCircle.y);
        Quaternion newRotation = Quaternion.LookRotation(Vector3.up);

        // Set the diamondsSpawned to 0
        DiamondsSpawned = 0;

        if (DiamondsSpawned == 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(randomPosition, Vector3.down, out hit, Mathf.Infinity, groundLayer))
            {
                if (hit.point.x <= maxHeight && hit.point.x >= minHeight)
                {
                    // Instantiate prefabs within a given radius. Set the radius in the inspecter
                    Instantiate(diamondPrefab, hit.point + new Vector3(0, heightOffset, 0), newRotation);
                    DiamondsSpawned++;
                    Debug.Log("DiamondSpawned succesfully");
                }
            }
        }
    }

    public static void DiamondCollected()
    {
        if (instance != null)
        {
            instance.DiamondsSpawned--;
            Debug.Log("Diamond collected, ready spawn the next.");
        }
    }
}
