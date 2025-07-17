using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDetection : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _target;
    [SerializeField] private float _viewAngle = 45f;
    [SerializeField] private float _sightDistance = 15f;
    [SerializeField] private LayerMask _whatIsObstacle;

    public bool CanSeePlayer() // sistema a trappole --> quando entra in un IF non può più uscire
    {
        Vector3 toTarget = _target.position - _head.position;
        float sqrDistance = toTarget.sqrMagnitude;

        if (sqrDistance > _sightDistance * _sightDistance)
        {
            Debug.Log($"{_target.gameObject.name} è troppo lontano da {gameObject.name}");
            return false;
        }

        float distance = Mathf.Sqrt(sqrDistance);
        toTarget /= distance; // Normalizza il vettore

        if (Vector3.Dot(_head.forward, toTarget) < Mathf.Cos(_viewAngle * Mathf.Deg2Rad)) // si può anche lasciare trasnform.forward se non si vuole usare i movimenti della testa
        {
            Debug.Log($"{_target.gameObject.name} NON è nei {_viewAngle} gradi davanti a {gameObject.name}");
            return false;
        }

        // 2 modi
        //Physics.Raycast(_head.position, toTarget, _sightDistance, _whatIsObstacle); // se colpisce qualcosa vuol dire che ho colpito un ostacolo

        if (Physics.Linecast(_head.position, _target.position + Vector3.up * 0.01f, _whatIsObstacle)) // se colpisce qualcosa vuol dire che ho colpito un ostacolo
        // gli sto dando un piccolo offset in y per evitare che il raycast colpisca il terreno
        {
            Debug.Log($"{_target.gameObject.name} è nascosto da un ostacolo rispetto a {gameObject.name}");
            return false;
        }

        Debug.Log($"{_target.gameObject.name} è nei {_viewAngle} gradi davanti a {gameObject.name}");
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
    }
}
