using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnPoint; // Use this to specify where bullets spawn
    [SerializeField] private float _shootDelay = 0.5f; // Time in seconds between bullet spawns
    private float _lastShotTime;
    private Queue<Bullet> _bulletPool = new Queue<Bullet>(); // voglio metterci i proiettili già utilizzati e metterli da parte per riutilizzarli

    public Bullet GetBullet()
    {
        Bullet bullet = null;
        if (_bulletPool.Count > 0)
        {
            bullet = _bulletPool.Dequeue(); // Get a bullet from the pool
            bullet.gameObject.SetActive(true); // Activate the bullet
        }
        else
        {
            bullet = Instantiate(_bulletPrefab); // Create a new bullet if the pool is empty
            bullet.Setup(this); // Set up the bullet with the spawner reference
        }
        return bullet;
    }

    public void ReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false); // Deactivate the bullet
        _bulletPool.Enqueue(bullet); // Add the bullet back to the pool
    }
 
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - _lastShotTime >= _shootDelay)
            {
                _lastShotTime = Time.time;
                Bullet b = GetBullet(); // Get a bullet from the pool or create a new one
                b.transform.position = _spawnPoint.position; // Set the bullet's position to the spawn point
                b.Shoot(_spawnPoint.forward); // Use the forward direction of the spawn point
            }
        }
    }
}
