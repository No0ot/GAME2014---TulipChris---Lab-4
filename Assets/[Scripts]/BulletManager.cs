using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public List<GameObject> bulletPool;

    public GameObject bulletPrefab;

    public int maxBullets;
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new List<GameObject>();

        BuildPool();
    }

    private void BuildPool()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.SetParent(transform);
            newBullet.SetActive(false);
            bulletPool.Add(newBullet);
        }
    }
    public GameObject getBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.SetParent(transform);
        bulletPool.Add(newBullet);

        return newBullet;
    }

    public void SpawnBullet(Vector3 position)
    {
        GameObject temp = getBullet();
        temp.transform.position = position;
        temp.SetActive(true);
    }
}
