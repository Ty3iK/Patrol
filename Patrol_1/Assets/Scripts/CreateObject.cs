using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _sphere;

    private Vector3 _startPosition;
    void Awake()
    {
        float x = Random.Range(-10, 10);
        float y = Random.Range(2, 9);
        float z = Random.Range(-140, -120);
        _startPosition = new Vector3(x, y, z);
        Instantiate(_sphere, _startPosition, Quaternion.identity);
    }

}
