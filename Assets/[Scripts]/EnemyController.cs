using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Movement")]
    public Bounds moveBounds;
    public Bounds startRange;

    [Header("Bullets")]
    public Transform bulletSpawn;
    public int frameDelay;

    public float startingPoint;
    public float randomSpeed;
    private BulletManager bulletManager;
    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(moveBounds.min, moveBounds.max);
        startingPoint = Random.Range(startRange.min, startRange.max);
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed) + startingPoint, transform.position.y);
    }

    private void FixedUpdate()
    {
        if(Time.frameCount % frameDelay == 0)
        {
            bulletManager.SpawnBullet(bulletSpawn.position);
        }
    }
}
