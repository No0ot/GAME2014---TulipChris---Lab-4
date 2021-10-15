using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public List<GameObject> enemyBulletPool;
    public List<GameObject> playerBulletPool;

    public int enemyMaxBullets;
    public int playerMaxBullets;

    private BulletFactory factory;
    // Start is called before the first frame update
    void Start()
    {
        enemyBulletPool = new List<GameObject>();
        playerBulletPool = new List<GameObject>();
        factory = GetComponent<BulletFactory>();

    }

    private GameObject AddBullet(BulletType type = BulletType.ENEMY)
    {
        GameObject newBullet = factory.CreateBullet(type);
        newBullet.transform.SetParent(transform);
        switch (type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Add(newBullet);
                break;
            case BulletType.PLAYER:
                playerBulletPool.Add(newBullet);
                break;
        }
        return newBullet;
    }

    public GameObject getBullet(BulletType type = BulletType.ENEMY)
    {
        switch (type)
        {
            case BulletType.ENEMY:
                foreach (GameObject bullet in enemyBulletPool)
                {
                    if (!bullet.activeInHierarchy)
                    {
                        return bullet;
                    }
                }
                break;
            case BulletType.PLAYER:
                foreach (GameObject bullet in playerBulletPool)
                {
                    if (!bullet.activeInHierarchy)
                    {
                        return bullet;
                    }
                }
                break;
        }
        return AddBullet(type);
    }

    public void SpawnBullet(Vector3 position, BulletType type)
    {
        GameObject temp = getBullet(type);
        temp.transform.position = position;
        temp.SetActive(true);
    }
}
