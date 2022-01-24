using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private Vector3 _currentPostion;

    private Rigidbody rb;
    private bool movingRight;

    private void Awake() => rb = GetComponent<Rigidbody>();

    private Vector3 GetPosition() => _currentPostion = rb.position;

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.z <= 298.73)
        {
            movingRight = true;
        }
        else if (transform.position.z >= 306.36)
        {
            movingRight = false;
        }

        if (movingRight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * _movingSpeed);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * _movingSpeed);
        }
    }
}