using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private float _jumpHeight= 2;

    [SerializeField] private GroundChecker _groundChecker;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_groundChecker == null) _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical"); //non sovrascrivere componente y altrimenti si perde componente gravità

        Vector3 direction = new Vector3(h, 0, v);

        if (direction.sqrMagnitude > 0.05f) // in questo modo si cerca di evitare che torni alla posizione iniziale
        {
            transform.forward = direction; // così sto settando la direzione dell'oggetto
        }

        Vector3 velocity = _rb.velocity;
        velocity.x = h * _speed;
        velocity.y = v * _speed;

        if (Input.GetButtonDown("Jump") && _groundChecker.IsGrounded)
        {
            velocity.y = _jumpForce;
            // _rb.AddForce() --> si può fare anche in questo modo --> però così aggiunge una forza, nell'altro modo la sovrascrive --> in questo caso se il personaggio sta cadendo aggiungerà una forza minore
            //velocity.y = Mathf.Sqrt(_jumpHeight * -2 * Physics.gravity.y); // questo ipotizzando che la gravità sia -9.81
        }


        _rb.velocity = velocity; // velocity è sempre rispetto alla scena, e non rispetto a camera --> quindi se camera posizionata nella direzione opposta, andare a destra fa muovere il personaggio a sinistra
    }
}
