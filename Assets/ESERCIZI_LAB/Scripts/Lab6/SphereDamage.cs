using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDamage : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 1; // Amount of damage the sphere will deal
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter(Collider other) // altrimenti con collision, si può scrivere collision.gameObject.CompareTag("Player")
    {
        if (other.CompareTag("Player"))
        {
            LifeControllerLab6 lifeController = other.GetComponent<LifeControllerLab6>();
            if (lifeController != null)
            {
                lifeController.TakeDamage(_damageAmount);
            }
        }
    }
}
