using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Creator : MonoBehaviour {

    public float CreationFrequancy;

    float leftBorder, rightBorder;

    public GameObject EnemyTemplate;
    public EnemyScriptableObject[] enemies;

    private void Start()
    {
        leftBorder = PlayerMovement.instance.minX;
        rightBorder = PlayerMovement.instance.maxX;

        StartCoroutine(EnemiesCreation());
    }

    IEnumerator EnemiesCreation()
    {
        while (true)
        {
            CreateEnemy();
            yield return new WaitForSeconds(CreationFrequancy);
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
        GameObject newEnemy = Instantiate(EnemyTemplate, newEnemyPosition, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().enemyScriptableObject = randomEnemy;
    }
}
