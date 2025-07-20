using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLab6 : MonoBehaviour
{
    [SerializeField] private float _initialSpeed = 3;
    private Rigidbody _rb;

    private float _speed;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);

        if (direction.sqrMagnitude > 0.05f)
        {
            //transform.forward = direction;

            // Smoothly rotate towards the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _initialSpeed;
            _speed *= 2; // Raddoppia la velocità quando si tiene premuto Shift
        }
        else
        {
            _speed = _initialSpeed; // Ripristina la velocità normale quando Shift non è premuto
        }

        _rb.MovePosition(_rb.position + direction * (_speed * Time.deltaTime));
    }
}
