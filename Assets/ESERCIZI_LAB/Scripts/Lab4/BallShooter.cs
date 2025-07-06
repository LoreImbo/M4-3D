using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    [SerializeField] private Bullet_Sphere _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _radius = 0.5f;
    [SerializeField] private LayerMask _layerMask; // Optional: specify which layers to consider for the sphere cast
    private Ray _ray;
    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.SphereCast(_ray, _radius, out RaycastHit hit);
            // if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
            Debug.Log("Hit: " + hit.collider.name + ", Point: " + hit.point);
            if (hit.collider.CompareTag("Wall"))
            {
                Debug.Log("Hit Wall");
            }
            else
            {
                Bullet_Sphere b = Instantiate(_bulletPrefab);
                b.transform.position = _spawnPoint.position;
                b.Shoot(_ray.direction); // Use the direction of the ray to shoot the bullet
            }
        }
    }
}
