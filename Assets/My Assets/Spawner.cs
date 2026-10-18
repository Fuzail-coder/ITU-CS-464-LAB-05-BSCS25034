using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float interval = 1f;
    [SerializeField] int maxCoins = 10;
    [SerializeField] float area = 4.5f;   
    [SerializeField] float height = 0.5f;

    void Start()
    {
        for (int i = 0; i < maxCoins; i++)
            SpawnCoin();

        InvokeRepeating(nameof(SpawnCoin), interval, interval);
    }

    void SpawnCoin()
    {
        if (transform.childCount >= maxCoins)
            return;

        float x = Random.Range(-area, area);
        float z = Random.Range(-area, area);
        Vector3 pos = transform.position + new Vector3(x, height, z);

        Instantiate(coinPrefab, pos, Quaternion.identity, transform);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + Vector3.up * height,
                            new Vector3(area * 2, 0.1f, area * 2));
    }
}