using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Text scoreText;

    public int score;
    public GameObject gameOverPanel;

    public static GameController instance;

    private void OnEnable()
    {
        Enemy.EnemyDeath += OnEnemyDeath;
        Player.PlayerDeath += OnPlayerDeath;
        Enemy.EnemiesAreOver += OnEnemiesAreOver;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        StartCoroutine(Difficulty());
        UpdateScore();
    }

    IEnumerator Difficulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            IncreaseDifficulty();
        }
    }

    void IncreaseDifficulty()
    {
        if (Enemies_Creator.instance.creationFrequancy > 0.7f)
            Enemies_Creator.instance.creationFrequancy -= 0.05f;
    }

    void OnEnemyDeath()
    {
        AddScore(10);            
    }

    void AddScore(int score)
    {
        this.score += score;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void Victory()
    {
        gameOverPanel.SetActive(true);
    }

    void OnPlayerDeath()
    {
        GameOver();
    }

    void OnEnemiesAreOver()
    {
        GameOver();
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public bool IsPlayerAlive()
    {
        return PlayerMovement.instance != null;
    }

    private void OnDisable()
    {
        Enemy.EnemyDeath -= OnEnemyDeath;
        Player.PlayerDeath -= OnPlayerDeath;
        Enemy.EnemiesAreOver -= OnEnemiesAreOver;
    }

}
