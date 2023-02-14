using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    public LevelObject level;

    public TMP_Text buttonTitle;
    public TMP_Text buttonHighscore;
    public TMP_Text buttonBestTime;

    private void Start() 
    {
        level.GetScores();
        
        buttonTitle.text = level.displayName;
        buttonHighscore.text = level.levelHighScore.ToString();
        buttonBestTime.text = DisplayExactTime(level.levelBestTime);
    }

    public void OnButtonPressed()
    {
        GameManager.Instance.LoadLevel(level.sceneName);
    }

    private string DisplayExactTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        
        string levelTime = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("000");

        return levelTime;
    }
}
