using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touched by: " + other.name + " | tag: " + other.tag);

        if (other.CompareTag("Player"))
            Collect();
    }
    void Collect()
    {
        GameManager.Instance.AddCoin(value);
        Destroy(gameObject);
    }
}