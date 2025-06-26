using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor_lab2 : MonoBehaviour
{
    private MeshRenderer _renderer;
    private Material _mat;
    private ColorManager_lab2 _colorManager;
    private Color _quadPrefabColor;
    [SerializeField] private GameObject _quadPrefab;
    private Camera _camera;
    private Ray _ray;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _mat = _renderer.material;
        _colorManager = FindObjectOfType<ColorManager_lab2>();
        _quadPrefabColor = _quadPrefab.GetComponent<MeshRenderer>().material.color;
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Color color = _quadPrefabColor;
            _colorManager.ChangeColor(color);
        }

        if (Input.GetMouseButton(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Color color = _colorManager._renderer.material.color;
                    _mat.SetColor("_BaseColor", color);
                }
            }
        }
    }
}
