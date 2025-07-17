using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererHandler : MonoBehaviour
{
    [SerializeField] private int _subdivisions = 12; // le suddivioni del cerchio
    [SerializeField] private float _circleRadius = 1.5f; // il raggio del cerchio
    private LineRenderer _lineRenderer;
    
    void Start()
    {
        _lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    public void EvaluateCircle(int subdivisions)
    {
        _lineRenderer.positionCount = subdivisions;

        Vector3[] positions = new Vector3[subdivisions];

        float deltaAngle = Mathf.PI * 2 / subdivisions; // calcolo l'angolo tra i punti del cerchio
        // bisogna settare loop su unity di modo che il cerchio si chiuda

        for (int i = 0; i < subdivisions; i++)
        {
            float currentAngle = i * deltaAngle; // calcolo l'angolo in radianti
            float x = Mathf.Cos(currentAngle) * _circleRadius; // calcolo la coordinata x
            float z = Mathf.Sin(currentAngle) * _circleRadius; // calcolo la coordinata z
            positions[i] = new Vector3(x, 0, z); // creo il punto nel piano XZ

            // si può fare anche così
            // positions[i].x = Mathf.Cos(currentAngle) * _circleRadius;
            // positions[i].y = 0;
            // positions[i].z = Mathf.Sin(currentAngle) * _circleRadius;
        }

        _lineRenderer.SetPositions(positions);
    }
    void Update()
    {
        
    }
}
