using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    private MeshRenderer _renderer;
    private Material _mat;
    private ColorManager _colorManager;
    private Color _quadPrefabColor;
    [SerializeField] private GameObject _quadPrefab;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _mat = _renderer.material;
        _colorManager = FindObjectOfType<ColorManager>();
        _quadPrefabColor = _quadPrefab.GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Color color = _quadPrefabColor;
            _colorManager.ChangeColor(color);
        }
    }
    
    private void OnMouseDown()
    {
        Color color = _colorManager._renderer.material.color;
        _mat.SetColor("_BaseColor", color);
    }
}
