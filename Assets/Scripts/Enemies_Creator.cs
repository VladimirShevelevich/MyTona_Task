using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Creator : MonoBehaviour {

    public int enemiesAmount;
    public float creationFrequancy;

    float leftBorder, rightBorder;

    public GameObject EnemyTemplate;
    public EnemyScriptableObject[] enemies;

    public delegate void EnemiesAreOverEventHandler();
    public static event EnemiesAreOverEventHandler EnemiesAreOver;
    public static Enemies_Creator instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        leftBorder = PlayerMovement.instance.minX;
        rightBorder = PlayerMovement.instance.maxX;

        StartCoroutine(EnemiesCreation());
    }

    IEnumerator EnemiesCreation()
    {
        while (enemiesAmount > 0)
        {
            CreateEnemy();
            yield return new WaitForSeconds(creationFrequancy);
        }
        OnEnemiesAreOver();
    }

    void CreateEnemy()
    {      
        Vector3 newEnemyPosition = new Vector3
            (Random.Range(leftBorder, rightBorder),
            transform.position.y,
                0
            );
        EnemyScriptableObject randomEnemy = enemies[Random.Range(0, enemies.Length)];
        GameObject newEnemy = Instantiate(EnemyTemplate, newEnemyPosition, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().enemyScriptableObject = randomEnemy;
        enemiesAmount--;        
    }

    void OnEnemiesAreOver()
    {
        if (EnemiesAreOver != null)
            EnemiesAreOver();
    }
}
