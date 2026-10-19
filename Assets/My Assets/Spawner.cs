using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [Header("Prefabs")]
    [SerializeField] GameObject yellowCoinPrefab;
    [SerializeField] GameObject redCoinPrefab;
    [SerializeField] GameObject blueCoinPrefab;

    [Header("Area (gizmo box)")]
    [SerializeField] float area = 4.5f;
    [SerializeField] float coinHeight = 0.5f;
    [SerializeField] Transform player;
    [SerializeField] float minDistanceFromPlayer = 1.5f;

    [Header("Blue")]
    [SerializeField] int blueCount = 50;
    [SerializeField] float blueRadius = 3f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnYellow();   
        SpawnRed();      
    }

    Vector3 RandomPoint()
    {
        Vector3 c = transform.position;
        Vector3 pos = c;

        for (int i = 0; i < 20; i++)
        {
            pos = new Vector3(
                c.x + Random.Range(-area, area),
                c.y + coinHeight,
                c.z + Random.Range(-area, area));

            if (player == null) break;

            Vector3 flat = pos - player.position;
            flat.y = 0f;
            if (flat.magnitude >= minDistanceFromPlayer) break;
        }
        return pos;
    }

    public void SpawnYellow()
    {
        Instantiate(yellowCoinPrefab, RandomPoint(), Quaternion.identity);
    }

    void SpawnRed()
    {
        Instantiate(redCoinPrefab, RandomPoint(), Quaternion.identity);
    }

    public void SpawnBlueCoins()
    {
        Vector3 c = transform.position;

        float limit = Mathf.Max(0f, area - blueRadius);
        Vector3 center = player.position;
        center.x = Mathf.Clamp(center.x, c.x - limit, c.x + limit);
        center.z = Mathf.Clamp(center.z, c.z - limit, c.z + limit);

        for (int i = 0; i < blueCount; i++)
        {
            float angle = i * Mathf.PI * 2f / blueCount;
            Vector3 pos = center + new Vector3(
                Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * blueRadius;
            pos.y = c.y + coinHeight;

            Instantiate(blueCoinPrefab, pos, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + Vector3.up * coinHeight,
                            new Vector3(area * 2, 0.1f, area * 2));
    }
}