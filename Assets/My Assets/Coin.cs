using UnityEngine;

public enum CoinKind { Yellow, Red, Blue }

public class Coin : MonoBehaviour
{
    public CoinKind type = CoinKind.Yellow;
    [SerializeField] float spinSpeed = 90f;

    bool collected = false;

    void Update()
    {
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (collected || !other.CompareTag("Player")) return;
        collected = true;

        GameManager.Instance.CoinCollected(type);
        Destroy(gameObject);
    }
}