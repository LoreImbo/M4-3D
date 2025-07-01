using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _initialSpeed = 3;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _jumpForce = 5f;
    private bool _canDoubleJump = false;
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
        
        if (_groundCheck.IsGrounded)
        {
            _canDoubleJump = true; // Reset double jump when grounded
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            if (_groundCheck.IsGrounded)
            {
                // Primo salto
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
            else if (_canDoubleJump)
            {
                // Doppio salto
                //_rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _canDoubleJump = false;
            }
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
