using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Text scoreText;

    int score;

    private void OnEnable()
    {
        Enemy.EnemyDeath += OnEnemyDeath;
        Enemies_Creator.EnemiesAreOver += OnEnemyAreOver;
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

    void OnEnemyAreOver()
    {

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

    private void OnDisable()
    {
        Enemy.EnemyDeath -= OnEnemyDeath;
        Enemies_Creator.EnemiesAreOver -= OnEnemyAreOver;
    }

}
