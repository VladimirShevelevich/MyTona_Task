using UnityEngine.Networking;
using UnityEngine;


public class PlayerMovement : NetworkBehaviour {

    public float speed;
    public float minX, maxX;

    float currentSpeed;

    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;
        if (GameController.instance.playMode)
            Move();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(Vector3.right * movement);

        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y, 0);
    }
}
