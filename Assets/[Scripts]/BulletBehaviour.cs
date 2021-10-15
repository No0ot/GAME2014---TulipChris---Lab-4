using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Bullet Movement")]
    [Range(0.0f, 10.0f)]
    public float speed;
    public Bounds bulletBounds;
    public BulletDirection direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
    }

    private void CheckBounds()
    {
        if(transform.position.y < bulletBounds.max)
        {
            this.gameObject.SetActive(false);
        }
    }
}
