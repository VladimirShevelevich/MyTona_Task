using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public EnemyScriptableObject enemyScriptableObject;

    int health;
    float fireRate;
    float nextFire;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = enemyScriptableObject.skin;
        health = enemyScriptableObject.health;
        fireRate = enemyScriptableObject.fireRate;
        GetComponent<DirectMoving>().speed = enemyScriptableObject.speed*-1;
    }

    private void Update()
    {
        if (Time.time > nextFire)
        {
            MakeShot();
            nextFire += 1 / fireRate;
        }
    }

    void MakeShot()
    {

    }
}
