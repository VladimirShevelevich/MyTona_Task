using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public EnemyScriptableObject enemyScriptableObject;

    int health;
    float fireRate;
    float nextFire;
    GameObject bullet;
    public bool isSelfDirected;

    private void Start()
    {
        DragScriptableObject();
    }

    void DragScriptableObject()
    {
        GetComponent<SpriteRenderer>().sprite = enemyScriptableObject.skin;
        health = enemyScriptableObject.health;
        fireRate = enemyScriptableObject.fireRate;
        GetComponent<DirectMoving>().speed = enemyScriptableObject.speed * -1;
        bullet = enemyScriptableObject.Bullet;
        isSelfDirected = enemyScriptableObject.isSelfDirected;
    }

    private void Update()
    {
        if (Time.time > nextFire)
        {
            MakeShot();
            nextFire += 1 / fireRate;
        }

        if (isSelfDirected)
            transform.up = transform.position - PlayerMovement.instance.transform.position;
    }

    void MakeShot()
    {
        
    }
}
