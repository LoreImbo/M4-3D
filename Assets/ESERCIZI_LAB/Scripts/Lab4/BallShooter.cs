using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
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
            Physics.SphereCast(_ray, 0.5f, out RaycastHit hit, 100f);
            if (hit.collider.CompareTag("Wall"))
            {
                Debug.Log("Hit Wall");
            }
        }
    }
}
