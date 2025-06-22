using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    private MeshRenderer _renderer;
    private Material _mat;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _mat = _renderer.material; // duplica il materiale e assegna a questo renderer il nuovo materiale
        //_mat = _renderer.sharedMaterial; // in questo modo le modifiche si vedono in tutti gli oggetti in scena
    }

    private void OnMouseDown()
    {
        Color color = _colors[Random.Range(0, _colors.Length)];
        _mat.color = color;
    }
}
