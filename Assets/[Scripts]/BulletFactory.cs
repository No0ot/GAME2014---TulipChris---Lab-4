using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [Header("Bullet Types")]
    public GameObject enemyBulletPrefab;
    public GameObject playerBulletPrefab;

    public GameObject CreateBullet(BulletType type = BulletType.ENEMY)
    {
        GameObject tempbullet = null;
        switch(type)
        {
            case BulletType.ENEMY:
                tempbullet = Instantiate(enemyBulletPrefab);
                break;
            case BulletType.PLAYER:
                tempbullet = Instantiate(playerBulletPrefab);
                break;
        }
        tempbullet.transform.parent = transform;
        tempbullet.SetActive(false);
        return tempbullet;
    }
}
