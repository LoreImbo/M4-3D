using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private BulletLab6 _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _fireRate = 0.5f; // Time in seconds between bullet spawns
    private float _lastShotTime;

    private Queue<BulletLab6> _bulletPool = new Queue<BulletLab6>(); 

    public BulletLab6 GetBullet()
    {
        BulletLab6 bullet = null;
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
    public void ReleaseBullet(BulletLab6 bullet)
    {
        bullet.gameObject.SetActive(false); // Deactivate the bullet
        _bulletPool.Enqueue(bullet); // Add the bullet back to the pool
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - _lastShotTime >= _fireRate)
            {
                _lastShotTime = Time.time;
                BulletLab6 b = GetBullet(); // Get a bullet from the pool or create a new one
                b.transform.position = _spawnPoint.position; // Set the bullet's position to the spawn point
                b.Shoot(_spawnPoint.forward); // Use the forward direction of the spawn point
            }
        }
    }
}
