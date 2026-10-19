using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public GameObject winPanel;

    public int yellowTarget = 10;   // win sirf yellow se

    int yellowCollected = 0;
    int bonusCollected = 0;
    bool won = false;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    void Start()
    {
        if (winPanel != null) winPanel.SetActive(false);
        else Debug.LogWarning("GameManager: winPanel assign nahi hai!");
        UpdateUI();
    }

    public void CoinCollected(CoinKind type)
    {
        if (won) return;

        switch (type)
        {
            case CoinKind.Yellow:
                yellowCollected++;
                UpdateUI();

                if (yellowCollected >= yellowTarget)
                    Win();
                else
                    Spawner.Instance.SpawnYellow();
                break;

            case CoinKind.Red:
                bonusCollected++;
                UpdateUI();
                Spawner.Instance.SpawnBlueCoins();
                break;

            case CoinKind.Blue:
                bonusCollected++;
                UpdateUI();
                break;
        }
    }
    void UpdateUI()
    {
        if (scoreText == null) return;
        scoreText.text = "Yellow: " + yellowCollected + " / " + yellowTarget
                       + "\nBonus: " + bonusCollected;
    }

    void Win()
    {
        won = true;
        if (winPanel != null) winPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}