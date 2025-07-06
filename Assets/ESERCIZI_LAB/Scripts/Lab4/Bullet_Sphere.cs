using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Sphere : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifetime = 5f;
    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void Shoot(Vector3 direction)
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();

        _rb.velocity = direction * _speed;
        _rb.angularVelocity = Vector3.zero; // Reset angular velocity to prevent spinning

        Destroy(gameObject, _lifetime); // Destroy the bullet after its lifetime
    }
    void Update()
    {
        
    }
}
