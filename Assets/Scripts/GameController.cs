using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Text scoreText;

    int score;
    public bool gameIsOver;

    public static GameController instance;

    private void OnEnable()
    {
        Enemy.EnemyDeath += OnEnemyDeath;
        Player.PlayerDeath += OnPlayerDeath;
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

    void Victory()
    {
        Debug.Log("Victory");
    }

    void OnPlayerDeath()
    {
        gameIsOver = true;
    }

    private void OnDisable()
    {
        Enemy.EnemyDeath -= OnEnemyDeath;
        Player.PlayerDeath -= OnPlayerDeath;
    }

}
