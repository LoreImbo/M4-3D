using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 180;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        _rb.MovePosition(_rb.position + transform.forward * (v * _moveSpeed * Time.fixedDeltaTime));

        //transform.Rotate(Vector3.up, h * _rotationSpeed * Time.fixedDeltaTime);

        _rb.MoveRotation(transform.rotation * Quaternion.Euler(0, h * _rotationSpeed * Time.fixedDeltaTime, 0)); // voglio ruotare intorno a y
    }
}
