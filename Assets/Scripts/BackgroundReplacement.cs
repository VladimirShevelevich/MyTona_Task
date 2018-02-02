using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundReplacement : MonoBehaviour {

    float size = 20.48f;

    private void Update()
    {
        if (transform.position.y < -size)
            Replace();
    }

    void Replace()
    {
        transform.position += Vector3.up * size * 2;
    }

}
