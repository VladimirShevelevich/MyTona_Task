using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject bullet;
    public float fireRate;
    public Transform Gun;

    float nextFire;
    Transform projectilesCollector;


    private void Start()
    {
        projectilesCollector = GameObject.Find("Projectiles").transform;
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
        Instantiate(bullet, Gun.position, Quaternion.identity,projectilesCollector);
    }

}
