using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public EnemyScriptableObject enemyScriptableObject;

    public GameObject hitEffect, destructionEffect;

    public delegate void EnemyDeathEventHandler();
    public static event EnemyDeathEventHandler EnemyDeath;

    int health;
    bool isSelfDirected;

    private void Start()
    {
        DragScriptableObject();
    }

    void DragScriptableObject()
    {
        GetComponent<SpriteRenderer>().sprite = enemyScriptableObject.skin;
        health = enemyScriptableObject.health;
        GetComponent<DirectMoving>().speed = enemyScriptableObject.speed * -1;
        isSelfDirected = enemyScriptableObject.isSelfDirected;
    }

    private void Update()
    {
        if (isSelfDirected && PlayerMovement.instance != null)
            transform.up = transform.position - PlayerMovement.instance.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            GetDamage();
        }
    }

    void GetDamage()
    {
        health--;
        if (health > 0)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
            SoundController.instance.PlaySound(SoundController.instance.hit);
        }
        else
            Desctruction();
    }

    void Desctruction()
    {
        Instantiate(destructionEffect, transform.position, Quaternion.identity);
        SoundController.instance.PlaySound(SoundController.instance.enemyExplosion);
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        OnEnemyDeath();
    }

    void OnEnemyDeath()
    {
        if (EnemyDeath != null)
            EnemyDeath();
    }
    
}
