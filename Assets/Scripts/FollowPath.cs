using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private Transform[] _destinations;
    private int _destinationIndex;
    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
        
    }

    public void SetDestinationAtPreviousIndex() => SetDestinationAtIndex(_destinationIndex - 1);
    //{
    //    int index = _destinationIndex - 1;
    //    //if (index < 0)
    //    //{
    //    //    // index += _destinations.Length; // Wrap around to the last index
    //    //    index = _destinations.Length - 1; // Wrap around to the last index
    //    //}
    //    while (index < 0)
    //    {
    //        index += _destinations.Length; // Ensure index is non-negative
    //    }
    //    SetDestinationAtIndex(index);
//
    //    //altra formula
    //    // int index = (_destinationIndex - 1) % _destinations.Length;
    //    // index = (index < 0) ? _destinations.Length + index : index;
    //}


    public void SetDestinationAtNextIndex() => SetDestinationAtIndex(_destinationIndex + 1);
    //{
    //    //int index = _destinationIndex + 1; --> facendo così prima o poi si va fuori range
    //    //int index = 0;
    //    //if (_destinationIndex + 1 == _destinations.Length)
    //    //{
    //    //    index = 0;
    //    //}
    //    //else
    //    //{
    //    //    index = _destinationIndex + 1;
    //    //}
//
    //    // questo sotto va bene
    //    //int index = (_destinationIndex + 1) % _destinations.Length; // This will wrap around to 0 if it exceeds the length
    //    //SetDestinationAtIndex(index);
    //}

    public void SetDestinationAtIndex(int index)
    {
        //if (index < 0 || index >= _destinations.Length)
        //{
        //    Debug.LogError($"Tried to Set Destination At Index {index}, but the max index is {_destinations.Length - 1}");
        //    return;
        //}
        if (index < 0)
        {
            while (index < 0)
            {
                index += _destinations.Length; // Ensure index is non-negative
            }
        }
        else if (index >= _destinations.Length)
        {
            index = index % _destinations.Length; // Wrap around to the start
        }
        _destinationIndex = index;
        _agent.SetDestination(_destinations[_destinationIndex].position);
    }

    public bool IsCloseEnoughToDestination()
    {
        float sqrStoppingDistance = _agent.stoppingDistance * _agent.stoppingDistance;
        Vector3 toDestination = _destinations[_destinationIndex].position - transform.position;
        float sqrDistance = toDestination.sqrMagnitude;
        if (sqrDistance <= sqrStoppingDistance + Mathf.Epsilon) // si aggiunge Mathf.Epsilon per evitare problemi di precisione
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCloseEnoughToDestination())
        {
            SetDestinationAtNextIndex();
        }
    }
}
