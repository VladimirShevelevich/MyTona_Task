using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject {

    public Sprite skin;
    public int health;
    public float fireRate;
    public float speed;
    public GameObject Bullet;
    public bool isSelfDirected;

}
