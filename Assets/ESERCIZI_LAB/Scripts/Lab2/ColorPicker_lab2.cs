using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker_lab2 : MonoBehaviour
{
    private MeshRenderer _renderer;
    private Material _mat;
    private ColorManager_lab2 _colorManager;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _mat = _renderer.material;
        _colorManager = FindObjectOfType<ColorManager_lab2>();
    }


    void OnMouseDown()
    {
        _colorManager.ChangeColor(_renderer.material.color);
    }
}
