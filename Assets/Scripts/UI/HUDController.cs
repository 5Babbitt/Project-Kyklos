using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    private static HUDController instance;
    public static HUDController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<HUDController>();
            }
            return instance;
        }
    }

    public LevelObject levelInfo;
    
    [Header("HUD Settings")]
    public Text timeTxt;
    public Text coinsTxt;
    public Text gemsTxt;
    [SerializeField] private float Timer;
    [SerializeField] private int coinPoints = 10;
    [SerializeField] private int gemPoints = 50;
    [SerializeField] private GameObject playerHUD;

    [Header("Pause Settings")]
    [SerializeField] private GameObject pauseMenu;
    public static bool isGamePaused = false;
    public bool playing;

    [Header("End Level Settings")]
    [SerializeField] private GameObject EndLevelMenu;
    [SerializeField] private Text levelName;
    [SerializeField] private Text levelScore;
    [SerializeField] private Text highScore;
    [SerializeField] private Text levelTime;
    [SerializeField] private Text bestTime;

    private void Start()
    {
        playerHUD.SetActive(true);
        pauseMenu.SetActive(false);
        EndLevelMenu.SetActive(false);
    }

    void Update()
    {
        GameTimer();
    }

    //Counts the time
    private void GameTimer()
    {
        if (playing == true)
        {
            Timer += Time.deltaTime;
            timeTxt.text = DisplayTime(Timer);
        }
    }

    //Converts time float to minutes and seconds
    private string DisplayTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        
        string levelTime = minutes.ToString("00") + ":" + seconds.ToString("00");

        return levelTime;
    }

    private string DisplayExactTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        
        string levelTime = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("000");

        return levelTime;
    }

    //Updates when you pick up a coin
    public void UpdateCoinValue(int coin)
    {
        coinsTxt.text = coin.ToString();
    }

    //Updates when you pick up a gem
    public void UpdateGemValue(int gem)
    {
        gemsTxt.text = gem.ToString();
    }

    //Resumes the game
    public void Resume()
    {
        Time.timeScale = 1f;
        playerHUD.SetActive(true);
        pauseMenu.SetActive(false);
        isGamePaused = false;
    }

    //Restarts the level
    public void Restart()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        GameManager.Instance.ResetLevel();
    }

    //Pauses the game
    public void Pause()
    {
        playerHUD.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    //Quits to main menu
    public void Quit()
    {
        Time.timeScale = 1f;
        GameManager.Instance.MainMenu();
    }

    //Brings up the end of level screen
    public void EndLevelScreen()
    {
        Time.timeScale = 0f;
        
        int coins = PlayerManager.Instance._coins;
        int gems = PlayerManager.Instance._gems;

        int points = (coins * coinPoints) + (gems * gemPoints);

        float time = Timer;

        levelName.text = levelInfo.displayName;

        levelTime.text = DisplayExactTime(time);
        levelScore.text = points.ToString();

        levelInfo.UpdateScores(points, time);
        levelInfo.GetScores();

        highScore.text = levelInfo.levelHighScore.ToString();
        bestTime.text = DisplayExactTime(levelInfo.levelBestTime);
        
        playerHUD.SetActive(false);
        pauseMenu.SetActive(false);
        EndLevelMenu.SetActive(true);

    }

    private void OnEnable()
    {
        InputManager.pausePressed += Pause;
    }

    private void OnDisable()
    {
        InputManager.pausePressed -= Pause;
    }
}
