using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeControllerLab6 : MonoBehaviour
{
    [SerializeField] private int _life = 10;
    [SerializeField] private UnityEvent _onDeath;
    [SerializeField] private UnityEvent<int, int> _onLifeChanged;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void TakeDamage(int damage)
    {
        _life -= damage;
        _onLifeChanged?.Invoke(_life, 10); // Passa il valore attuale della vita e il massimo (10 in questo caso)
        if (_life <= 0)
        {
            _onDeath?.Invoke(); // questa parte a destra non la esegue se _onDeath è null --> abbreviazione di (if (_onDeath != null) _onDeath.Invoke();)
            Destroy(gameObject);
        }
    }
}
