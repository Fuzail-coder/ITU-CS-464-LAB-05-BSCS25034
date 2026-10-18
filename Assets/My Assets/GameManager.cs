using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int coinCount = 0;
    public TextMeshProUGUI scoreText;
    public GameObject winPanel;
    public int normalTarget = 10;   // itne normal coins ke baad blue aayenge
    public int targetScore = 60;    // 10 normal + 50 blue

    bool blueStarted = false;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    void Start()
    {
        winPanel.SetActive(false);
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        coinCount += amount;
        UpdateUI();

        if (!blueStarted && coinCount >= normalTarget)
        {
            blueStarted = true;
            Spawner.Instance.SpawnBlueCoins();
        }

        if (coinCount >= targetScore) Win();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + coinCount;
    }

    void Win()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;   // button click ke liye mouse wapas
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        var s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.buildIndex);
    }
}