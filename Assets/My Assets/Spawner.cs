using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField] GameObject coinPrefab;
    [SerializeField] float interval = 1.5f;
    [SerializeField] int maxCoins = 1;
    [SerializeField] int totalCoins = 10;
    [SerializeField] float area = 4.5f;

    [Header("Blue")]
    [SerializeField] GameObject blueCoinPrefab;
    [SerializeField] int blueCount = 50;
    [SerializeField] Transform player;

    int spawned = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 1f, interval);
    }

    void SpawnCoin()
    {
        if (transform.childCount >= maxCoins)
            return;
        float x = Random.Range(-area, area);
        float z = Random.Range(-area, area);
        var pos = new Vector3(x, 0.5f, z);
        Instantiate(coinPrefab, pos, Quaternion.identity, transform);

        spawned++;
        if (spawned >= totalCoins)
            CancelInvoke(nameof(SpawnCoin));
    }

    public void SpawnBlueCoins()
    {
        for (int i = 0; i < blueCount; i++)
        {
            Vector2 r = Random.insideUnitCircle.normalized;
            Vector3 pos = player.position
                + new Vector3(r.x, 0f, r.y) * 6f;

            Instantiate(blueCoinPrefab, pos, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + Vector3.up * 0.5f,
                            new Vector3(area * 2, 0.1f, area * 2));
    }
}