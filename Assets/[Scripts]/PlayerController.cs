using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [Range(0.0f, 500.0f)]
    public float horizontalforce;
    [Range(0.0f, 1.0f)]
    public float decay;
    public Bounds bounds;

    private Rigidbody2D rb;
    private BulletManager bulletManager;

    [Header("Player Attack")]
    public Transform bulletSpawn;
    public int frameDelay;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
        CheckFire();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");

        rb.AddForce(new Vector2(x * horizontalforce * Time.deltaTime, transform.position.y));

        rb.velocity *= 1.0f - decay;
    }

    private void CheckBounds()
    {
        if (transform.position.x < bounds.min)
            transform.position = new Vector2(bounds.min, transform.position.y);

        if (transform.position.x > bounds.max)
            transform.position = new Vector2(bounds.max, transform.position.y);
    }

    private void CheckFire()
    {
        if((Time.frameCount % frameDelay == 0) && (Input.GetAxisRaw("Jump") > 0))
        {
            bulletManager.SpawnBullet(bulletSpawn.position, BulletType.PLAYER);
        }
    }
}
