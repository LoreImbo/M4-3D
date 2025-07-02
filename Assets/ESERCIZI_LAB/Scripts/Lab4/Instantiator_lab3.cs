using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator_lab3 : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    private Transform _parentTransform;
    [SerializeField] private int _rows = 10;
    [SerializeField] private int _cols = 10;
    [SerializeField] private float _offset1 = 1.1f;
    [SerializeField] private float _offset2 = 1.1f;

    void Start()
    {
        Instantiator();
    }

    void Instantiator()
    {
        for (int y = 0; y < _cols; y++)
        {
            for (int x = 0; x < _rows; x++)
            {   
                Vector3 position = new Vector3(x * _offset1, y * _offset2, 0);
                Instantiate(_cubePrefab, position, Quaternion.identity, this.transform);
            }
        }
    }
}
