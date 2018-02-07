using UnityEngine.Networking;
using UnityEngine;
using System;

public class Player : NetworkBehaviour {

    public GameObject destructionVFX;

    public delegate void PlayerDeathEventHandler();
    public static event PlayerDeathEventHandler PlayerDeath;

    public override void OnStartLocalPlayer()
    {
        ChangeColor();
    }

    void ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

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
        OnPlayerDeath();
        Destroy(gameObject);
    }

    void OnPlayerDeath()
    {
        if (PlayerDeath != null)
            PlayerDeath();
    }
}
