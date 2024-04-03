using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("Refrences")]
    [SerializeField] GameObject objTurret;
    [SerializeField] GameObject objGameOver;
    [SerializeField] internal Effects effects;
    [SerializeField] internal ObjectPooler objectPooler;

    [Header("UI")]
    [SerializeField] Text txtScore;
    [SerializeField] Text txtHighscore;
    [SerializeField] Text txtGameOverScore;
    [SerializeField] Text txtGameOverHighscore;

    private int score;
    private int highScore;
    internal bool isGameOver;


    private void Start()
    {
        isGameOver = false;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScore(0);
    }


    private void DestroyTurret()
    {
        isGameOver = true;
        objTurret.SetActive(false);
        effects.TurretDestroy(objTurret.transform.position);
    }

    private void ActiveUI()
    {
        objGameOver.SetActive(true);
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

    internal void GameOver()
    {
        txtGameOverScore.text =$"Score: {score}";
        txtGameOverHighscore.text = $"HighScore: {highScore}";

        CancelInvoke();
        Invoke(nameof(DestroyTurret), 3);
        Invoke(nameof(ActiveUI), 8);
    }


    public void ButtonRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}