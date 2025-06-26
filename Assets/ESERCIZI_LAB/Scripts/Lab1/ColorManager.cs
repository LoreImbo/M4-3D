using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public MeshRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void ChangeColor(Color color)
    {
        _renderer.material.color = color;
    }
}
