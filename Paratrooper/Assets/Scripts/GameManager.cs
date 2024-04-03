using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("Refrences")]
    [SerializeField] internal Effects effects;
    [SerializeField] internal ObjectPooler objectPooler;

    [Header("UI")]
    [SerializeField] Text txtScore;
    [SerializeField] Text txtHighscore;

    private int score;
    private int highScore;


    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScore(0);
    }


    internal void UpdateScore(int val)
    {
        score += val;
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        txtScore.text = $"Score: {score}";
        txtHighscore.text = $"HighScore: {highScore}";
    }
}