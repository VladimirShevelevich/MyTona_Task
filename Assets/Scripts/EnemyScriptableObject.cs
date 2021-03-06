﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject {

    public Sprite skin;
    public int health;
    public float speed;
    public bool isSelfDirected;

}
