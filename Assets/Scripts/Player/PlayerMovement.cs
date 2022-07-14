using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : UnityEngine.MonoBehaviour
    {
        [SerializeField] private float       _speed;
        private                  Transform[] _wayPointPosition;
        private                  int         _currentLineIndex;
        private                  int         _countLineOnWay;
        private                  bool        _isMove;
        
        public void Init(Transform[] wayPoint)
        {
            _wayPointPosition  = wayPoint;
            transform.position = wayPoint[0].position;
            _currentLineIndex  = 0;
            _countLineOnWay    = wayPoint.Length - 1;
        }

        public void StartMove()
        {
            _isMove = true;
        }

        private void Update()
        {
            if (_isMove==false)
            {
                return;
            }

            Move();
        }

        private void Move()
        {
            if (transform.position ==_wayPointPosition[_currentLineIndex].position)
            {
                _currentLineIndex++;
                if (_currentLineIndex>=_wayPointPosition.Length)
                {
                    _isMove = false;
                    return;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, _wayPointPosition[_currentLineIndex].position,
                                                     _speed * Time.deltaTime);
        }
    }
}