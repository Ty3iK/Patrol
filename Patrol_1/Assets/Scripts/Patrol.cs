using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _timeSleep;

    [SerializeField]
    private int _countOfBreikPoint;

    private List<Vector3> _journy;
    private Vector3 _startPosition;
    private Vector3 _nextPosition;
    private int _counter;
    private float _timeCounter;
    private float _relocationTime;
    private float _timeToTravel;
    private float _distanceBeetwinBreiksOfPoint;

    void Start()
    {
        if (_countOfBreikPoint > 0)
            _journy = new List<Vector3>(_countOfBreikPoint);
        else
            Debug.Log("Fatal error!");
        _journy.Add(transform.position);
        AddBreikPoint();
    }

    // Update is called once per frame
    void Update()
    {
        _timeCounter += Time.deltaTime;
        if (_counter == _countOfBreikPoint)
            _counter = 0;
        if (_timeCounter >= _timeSleep)
        {
            if (_counter < _countOfBreikPoint - 1)
            {
                _startPosition = _journy[_counter];
                _nextPosition = _journy[_counter + 1];
            }
            else
            {
                _startPosition = _journy[_counter];
                _nextPosition = _journy[0];
            }
            _distanceBeetwinBreiksOfPoint = Vector3.Distance(_startPosition, _nextPosition);
            _timeToTravel = _distanceBeetwinBreiksOfPoint / _speed;
            _relocationTime += Time.deltaTime;

            transform.position = Vector3.Lerp(_startPosition, _nextPosition, _relocationTime / _timeToTravel);

            if (_relocationTime >= _timeToTravel)
            {
                _relocationTime = 0;
                _timeCounter = 0;
                _counter++;
            }

        }

    }

    private void AddBreikPoint()
    {
        for (int i = 1; i < _countOfBreikPoint; i++)
        {
            _journy.Add(new Vector3(Random.Range(-10, 10), Random.Range(2, 9), Random.Range(-140, -120)));
            // Debug.Log(_journy[i].x + " " + _journy[i].y + " " + _journy[i].z);
        }
    }
    // private void GoingToNewPosition()
    // {
    //     if (_counter < _countOfBreikPoint && _relocationTime <= _timeToTravel)
    //     {
    //         if (_countOfBreikPoint - _counter == 1)
    //             _nextPosition = _journy[0];
    //         else
    //             _nextPosition = _journy[_counter + 1];
    //
    //         _startPosition = transform.position;
    //         var distance = Vector3.Distance(_startPosition, _nextPosition);
    //         _timeToTravel = distance / _speed;
    //         _relocationTime += Time.deltaTime;
    //
    //         transform.position = Vector3.Lerp(_startPosition, _nextPosition, _relocationTime / _timeToTravel);
    //
    //         _counter++;
    //     }
    //     else
    //     {
    //         _relocationTime = 0;
    //         _timeCounter = 0;
    //         _counter = 0;
    //         //GoingToNewPosition();
    //     }
    // }

}
