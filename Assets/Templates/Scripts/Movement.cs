using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody _player;

    [SerializeField] private float _movementForce = 10f;
    [SerializeField] private float _maxVel = 10f;
    [SerializeField] private int jumpForce = 90;

    private bool isGrounded;

    private void Awake() => _player = GetComponent<Rigidbody>();

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_player.velocity.magnitude >= _maxVel)
            return;

        if (Input.GetKey(KeyCode.W))
            _player.AddForce(Vector3.forward * _movementForce);

        if (Input.GetKey(KeyCode.A))
            _player.AddForce(Vector3.left * _movementForce);

        if (Input.GetKey(KeyCode.S))
            _player.AddForce(Vector3.back * _movementForce);

        if (Input.GetKey(KeyCode.D))
            _player.AddForce(Vector3.right * _movementForce);
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        if (collision.gameObject.name.Equals("MovingPlatform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void Jump()
    {
        isGrounded = false;
        _player.AddForce(new Vector3(0, jumpForce, 0));
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Equals("MovingPlatform"))
        {
            this.transform.parent = null;
        }
    }
}