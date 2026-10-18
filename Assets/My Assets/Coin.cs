using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] float spinSpeed = 90f;
    public bool isRed = false;

    void Update()
    {
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Coin touched by {other.name}");
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(value);

            if (isRed)
                Spawner.Instance.SpawnBlueCoins();

            Destroy(gameObject);
        }
    }
}