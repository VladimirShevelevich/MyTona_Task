using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    float currentSpeed;

    private void Update()
    {
        currentSpeed += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    }
}
