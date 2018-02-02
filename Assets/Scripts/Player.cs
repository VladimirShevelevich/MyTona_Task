using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject destructionVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destruction();
        }
    }
    
    void Destruction()
    {
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        SoundController.instance.PlaySound(SoundController.instance.playerExplosion);
        Destroy(gameObject);
    }
}
