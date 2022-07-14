using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WayCreator : MonoBehaviour
{
    [SerializeField] private Transform[]   _points;
    [SerializeField] private KnifeMovement _knifePrefab;
    private                  KnifeMovement _knife;
    private                  Action        _onComplited;

    public Transform[] WayPoints => _points;
    

    public void Init(Action onComplited)
    {
        _onComplited = onComplited;
        CreateWay();
         _knife = Instantiate(_knifePrefab, _points[0].position, Quaternion.identity, null);
         _knife.Init(_points);
         _knife.OnFinished += FinishedCreateWay;
    }

    private void CreateWay()
    {
        for (int i = 1; i < _points.Length-1; i++)
        {
            var direction = Random.Range(0f, 2f) < 1 ? transform.right : -transform.right;
            _points[i].position += direction * Random.Range(0.5f, 1.5f);
        }
    }

    private void FinishedCreateWay()
    {
        _knife.OnFinished -= FinishedCreateWay;
        _onComplited?.Invoke();
    }
}
