using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _jumpForce = 5;


    private CharacterController _characterController;
    private Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v) * _speed;

        //_characterController.SimpleMove(move * Time.deltaTime); // simple move ignora l'asse y, ma unity in automatico applica la gravità

        if (Input.GetButtonDown("Jump") && _groundChecker.IsGrounded)
        {
            _velocity.y = _jumpForce;
        }

        if (_groundChecker.IsGrounded)
        {
            _velocity.y = 0;
        }
        else
        {
            _velocity.y = _gravity * Time.deltaTime; // questo perché accelerazione è gravità al secondo
        }
         
        move += _velocity;

        _characterController.Move(move * Time.deltaTime); // questo perché velocità è accelerazione al secondo
    }
}
