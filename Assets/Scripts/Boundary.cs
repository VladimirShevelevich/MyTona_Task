﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

    public void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
