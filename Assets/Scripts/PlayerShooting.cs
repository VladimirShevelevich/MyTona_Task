using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject bullet;
    public float fireRate;
    public Transform Gun;

    float nextFire;
    Transform projectilesCollector;
    ParticleSystem gunVFX;

    private void Start()
    {
        projectilesCollector = GameObject.Find("Projectiles").transform;
        gunVFX = Gun.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Time.time > nextFire && GameController.instance.playMode)
        {
            MakeShot();
            nextFire = Time.time + 1 / fireRate;
        }
    }

    void MakeShot()
    {
        Instantiate(bullet, Gun.position, Quaternion.identity,projectilesCollector);
        gunVFX.Play();
    }

}
