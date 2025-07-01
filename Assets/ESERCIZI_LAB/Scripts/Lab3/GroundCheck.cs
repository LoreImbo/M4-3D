using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 0.1f;
    [SerializeField] private LayerMask _whatIsGround;
    public bool IsGrounded { get; private set; }

    void Start()
    {

    }

    void Update()
    {
        IsGrounded = Physics.Raycast(transform.position, -Vector3.up, _maxDistance, _whatIsGround);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - Vector3.up * _maxDistance);
    }
}
