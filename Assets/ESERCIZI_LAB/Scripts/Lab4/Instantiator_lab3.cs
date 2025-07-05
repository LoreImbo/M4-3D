using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator_lab3 : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private int _rows = 10;
    [SerializeField] private float _offset1 = 1.1f;

    void Start()
    {
        Instantiator();
    }

    void Instantiator()
    {
        for (int x = 0; x < _rows; x++)
        {   
            Vector3 position = new Vector3(x * _offset1, 0, 0);
            Instantiate(_cubePrefab, _parentTransform.position + position, Quaternion.identity, _parentTransform);
        }
    }
}
