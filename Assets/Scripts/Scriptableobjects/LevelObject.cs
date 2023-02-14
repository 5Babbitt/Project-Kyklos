using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Level Object")]
public class LevelObject : ScriptableObject
{
    public string sceneName;
    public string displayName;
    public int levelHighScore;
    public float levelBestTime;

    private void Start() 
    {
        GetScores();
    }

    //Compares input score and time with the saved highscore and best time
    public void UpdateScores(int score, float time)
    {
        if (score > levelHighScore)
        {
            PlayerPrefs.SetInt(sceneName + "Highscore", score);
        }

        if (time < levelBestTime)
        {
            PlayerPrefs.SetFloat(sceneName + "BestTime", time);
        }
    }

    //Gets the saved score and time values
    public void GetScores()
    {
        levelHighScore = PlayerPrefs.GetInt(sceneName + "Highscore", 0);
        levelBestTime = PlayerPrefs.GetFloat(sceneName + "BestTime", 1000000);
    }
}
