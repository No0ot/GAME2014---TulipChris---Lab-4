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
    private Rigidbody2D rb;

    public Bounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
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

}
