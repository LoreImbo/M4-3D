using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 3;
    [SerializeField] private float _explosionForce = 100;
    [SerializeField] private float _explosionDelay = 3;
    [SerializeField] private LayerMask _targerLayers;
    private Collider[] _colliders = new Collider[10];


    public void Explode()
    {
        // OverlapSphere alloca memoria nella heap, c'è un alternativa --> int amount = OverlapSphereNonAlloc(transform.position, _explosionRadius, _colliders, _targerLayers, QueryTriggerInteraction.Ignore) --> restituisce il numero di elementi toccati in questo caso da questa esplosione, dove _colliders
        // in questo caso non si da più foreach ma for(int = 0; i < amount; i++) perché cicla solo su quelli oggetti che ha trovato --> Collider c = _colliders[i];
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius, _targerLayers, QueryTriggerInteraction.Ignore);

        foreach (Collider c in colliders) // molto simile al ciclo for di python
        {
            if (c.attachedRigidbody != null) // property dei collider che restituisce il Rigidbody collegato all'oggetto con collider
            {
                Vector3 direction = c.transform.position - transform.position; // qua calcolo la direzione tra il collider e l'oggetto stesso
                direction.Normalize();
                c.attachedRigidbody.AddForce(direction * _explosionForce, ForceMode.VelocityChange); //.Force è per la forza continua, .Impulse è la schicchera --> però entrmabe prendono in considerazione la massa dell'oggetto; .Acceleration e .VelocityChange sono i corrispettivi senza considerare la massa

            }
        }
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);

    }
    void Start()
    {
        Invoke("Explode", _explosionDelay); // permette di richiamare un'altra funzione (Explode) e utilizzarla dopo tot secondi
        // esiste anche InvokeRepeating che permette di andare a ripetizione
    }

    void Update()
    {
        
    }
}
