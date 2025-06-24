using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    private MeshRenderer _renderer;
    private Material _mat;
    private ColorManager _colorManager;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _mat = _renderer.material;
        _colorManager = FindObjectOfType<ColorManager>();
    }


    void OnMouseDown()
    {
        _colorManager.ChangeColor(_renderer.material.color);
    }
}
