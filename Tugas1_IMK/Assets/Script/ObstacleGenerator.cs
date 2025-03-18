using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] coinPrefabs;
    public Transform player;
    public Vector3 spawnPosition;

    public float coinChance = 0.3f;
    public float distanceBetweenObstacle = 15f;
    public float horizonDistance = 200f;

    void Update()
    {
        if (player == null || obstaclePrefabs.Length == 0) return; // Hindari error jika tidak ada player atau prefab

        float distance = Vector3.Distance(player.position, spawnPosition);

        if (distance < horizonDistance)
        {
            int x = Random.Range(-3, 4);
            spawnPosition = new Vector3(x, 1.5f, spawnPosition.z + distanceBetweenObstacle);

            if (Random.value < coinChance)
            {
                spawnPosition.y = 0.6f;
                GameObject coinPrefab = coinPrefabs[Random.Range(0, coinPrefabs.Length)];
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
                Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}