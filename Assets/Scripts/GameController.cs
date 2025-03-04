using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public TextMeshProUGUI coinCounterLabel;
    public GameObject scoreboard;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI timerLabel;
    [Range(1, 60)]
    [Tooltip("Duration of the mini game in seconds")]
    public float miniGameDuration = 30f;

    private int _coinBalance;
    private bool _isMiniGameActive = true;
    private float _remainingMiniGameDuration;
    private int _startingCoinBalance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _isMiniGameActive = true;
        _remainingMiniGameDuration = miniGameDuration;
        _startingCoinBalance = _coinBalance;
    }

    void Update()
    {
        if (_isMiniGameActive)
        {
            _remainingMiniGameDuration = Mathf.Max(0, _remainingMiniGameDuration - Time.deltaTime);

            if (_remainingMiniGameDuration == 0)
            {
                EndMiniGame();
            }

            UpdateCoinCounter();
            UpdateMiniGameTimer();
        }

        UpdateMiniGameScoreboard();
    }

    public void ShowRoom()
    {
        // Unpause game
        Time.timeScale = 1f;

        SceneManager.LoadScene("Room", LoadSceneMode.Single);
    }

    private void StartMiniGame()
    {
        _isMiniGameActive = true;
        _remainingMiniGameDuration = miniGameDuration;
        _startingCoinBalance = _coinBalance;

        // Unpause game
        Time.timeScale = 1f;

        SceneManager.LoadScene("Minigame", LoadSceneMode.Single);
    }

    private void EndMiniGame()
    {
        _isMiniGameActive = false;

        // Pause game
        Time.timeScale = 0f;
    }

    private void UpdateCoinCounter()
    {
        coinCounterLabel.text = _coinBalance.ToString();
    }

    private void UpdateMiniGameScoreboard()
    {
        var coinsGained = Mathf.Max(0, _coinBalance - _startingCoinBalance);
        scoreboard.SetActive(!_isMiniGameActive);
        scoreLabel.text = coinsGained == 1 ? $"{coinsGained} Coin" : $"{coinsGained} Coins";
    }

    private void UpdateMiniGameTimer()
    {
        var seconds = Mathf.FloorToInt(_remainingMiniGameDuration % 60);
        timerLabel.text = seconds.ToString();
    }

    public int GetCoinBalance()
    {
        return _coinBalance;
    }

    public void ModifyCoinBalance(int amount)
    {
        _coinBalance = Mathf.Max(0, _coinBalance + amount);
    }
}
