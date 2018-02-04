using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Creator : MonoBehaviour {

    public int enemiesAmount;
    public float creationFrequancy;

    float leftBorder, rightBorder;

    public GameObject EnemyTemplate;
    public EnemyScriptableObject[] enemies;
    public Transform EnemiesParent;
    
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
        while (enemiesAmount > 0 && GameController.instance.playMode)
        {
            CreateEnemy();
            yield return new WaitForSeconds(creationFrequancy);
        }
    }

    void CreateEnemy()
    {      
        Vector3 newEnemyPosition = new Vector3
            (Random.Range(leftBorder, rightBorder),
            transform.position.y,
                0
            );
        EnemyScriptableObject randomEnemy = enemies[Random.Range(0, enemies.Length)];
        GameObject newEnemy = Instantiate(EnemyTemplate, newEnemyPosition, Quaternion.identity, EnemiesParent);
        newEnemy.GetComponent<Enemy>().enemyScriptableObject = randomEnemy;
        enemiesAmount--;        
    }
}
