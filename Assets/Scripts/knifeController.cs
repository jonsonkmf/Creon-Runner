using System;
using System.Collections;
using System.Collections.Generic;
using BzKovSoft.ObjectSlicerSamples;
using UnityEngine;

public class knifeController : MonoBehaviour
{
    [SerializeField] private BzKnife       _knife1;
    [SerializeField] private BzKnife       _knife2;
    [SerializeField] private WayCleaner    _wayCleaner;
    private                  KnifeMovement _knifeMovement;

    public void Init(KnifeMovement knifeMovement)
    {
        _knifeMovement                  =  knifeMovement;
        _knifeMovement.AchievedEndPoint += AchievedEndPoint;
        AchievedEndPoint(0);
    }

    private void OnDisable()
    {
        if (_knifeMovement!=null)
        {
            _knifeMovement.AchievedEndPoint -= AchievedEndPoint;
        }
       
    }

    private void OnDestroy()
    {
        if (_knifeMovement !=null)
        {
            _knifeMovement.AchievedEndPoint -= AchievedEndPoint;
        }
    }

    private void AchievedEndPoint(int obj)
    {
        switch (obj)
        {
            case 0:
                _knife1.gameObject.SetActive(true);
                _knife2.gameObject.SetActive(false);
                _wayCleaner.gameObject.SetActive(false);
                break;
                
            case 1:
                _knife1.gameObject.SetActive(false);
                _knife2.gameObject.SetActive(true);
                _wayCleaner.gameObject.SetActive(false);
                break;
            
            case 2:
                _knife1.gameObject.SetActive(false);
                _knife2.gameObject.SetActive(false);
                _wayCleaner.gameObject.SetActive(true);
                break;
            default: 
                _knife1.gameObject.SetActive(true);
                _knife2.gameObject.SetActive(false);
                _wayCleaner.gameObject.SetActive(false);
                break;
        }
    }
}
