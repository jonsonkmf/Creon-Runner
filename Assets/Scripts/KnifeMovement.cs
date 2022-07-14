using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    [SerializeField] private knifeController _knifeController;
    private                  Transform[]     _points;
    private                  int             _CurrentIndex;
    private                  int             _finishedCount;
    public event Action                      OnFinished;

    public event Action<int> AchievedEndPoint;
    
    public void Init(Transform[] points)
    {
        _points = points;
        MoveToNextPoint(0);
        _knifeController.Init(this);
    }
    
    [ContextMenu("MoveToNextPoint")]
    private void MoveToNextPoint()
    {
        _CurrentIndex += 1;
        MoveToNextPoint(_CurrentIndex);

    }
    private void MoveToNextPoint(int index)
    {

        StartCoroutine(Move(_points[index].position));

    }

    [ContextMenu("Reset")]
    private void Reset()
    {
        _CurrentIndex      = 0;
        transform.position = _points[0].position;
        MoveToNextPoint();
    }

    private IEnumerator Move(Vector3 targetPosition)
    {
        transform.LookAt(targetPosition);
        var   startPosition = transform.position;
        float progress      = 0.01f;
        if (_finishedCount!=2)
        {
            while ( progress <=2)
            {
                progress           += Time.deltaTime*5;
                transform.position =  Vector3.LerpUnclamped(startPosition+transform.forward*2, startPosition-transform.forward*2, progress);
                yield return null;
            }
            progress = 0.01f;
        }

        while ( progress<=1)
        {
            progress           += Time.deltaTime *5;
            transform.position =  Vector3.Lerp(startPosition, targetPosition, progress);
            yield return null;
        }

        if (_CurrentIndex<_points.Length-1)
        {
            MoveToNextPoint();
        }
        else
        {
            if (_finishedCount>=2)
            {
                OnFinished?.Invoke();
                yield break;
            }
            Reset();
            _finishedCount+=1;
            AchievedEndPoint?.Invoke(_finishedCount);
        }
        yield return null;
    }
}
