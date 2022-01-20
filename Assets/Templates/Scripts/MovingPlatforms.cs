using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Vector3 _endPos;
    [SerializeField] private decimal _movingSpeed;

    private bool crossLimit;

    private void Awake() => _startPos = transform.position;

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.z >= _startPos.z)
        {
            transform.position = _endPos;
        }
        else
        {
            transform.position = _startPos;
        }
    }
}