using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLab6 : MonoBehaviour
{
    [SerializeField] private float _speed = 20f; // Speed of the bullet
    [SerializeField] private float _lifeTime = 5f; // Lifetime of the bullet
    [SerializeField] private int _damageAmount = 1; // Amount of damage the bullet will deal
    private Rigidbody _rb;
    private PlayerShootController _spawner;

    public void Setup(PlayerShootController spawner)
    {
        _spawner = spawner;
    }

    public void ReturnToPool()
    {
        // If the bullet is still active in the scene, we don't want to return it to the pool
        //if (gameObject.activeInHierarchy) return;

        // Deactivate the bullet and return it to the pool
        _spawner.ReleaseBullet(this);
    }
    public void Shoot(Vector3 direction)
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();

        _rb.velocity = direction * _speed;
        _rb.angularVelocity = Vector3.zero; // Reset angular velocity to prevent spinning

        CancelInvoke(); // Cancel any previous invocations of ReturnToPool
        //Destroy(gameObject, _lifeTime);
        Invoke(nameof(ReturnToPool), _lifeTime); // Return the bullet to the pool after its lifetime
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            LifeControllerLab6 lifeController = other.GetComponent<LifeControllerLab6>();
            if (lifeController != null)
            {
                lifeController.TakeDamage(_damageAmount); // Deal damage to the enemy
            }
            CancelInvoke(); // Cancel the invocation of ReturnToPool if the bullet collides with something
            ReturnToPool(); // Return the bullet to the pool instead of destroying it
        }

    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    //Destroy(gameObject);
    //    CancelInvoke(); // Cancel the invocation of ReturnToPool if the bullet collides with something
    //    ReturnToPool(); // Return the bullet to the pool instead of destroying it
    //}
}
