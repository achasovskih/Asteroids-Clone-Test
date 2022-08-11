using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 1, _moveSpeed = 3;

    private Rigidbody2D _rigidBody;
    private float _moveDirection;
    private float _turnDirection;


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _turnDirection = Input.GetAxis("Horizontal");
        _moveDirection = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {

        if (_moveDirection != 0 || _turnDirection != 0)
        {
            _rigidBody.AddForce(Vector2.up * -_moveDirection * -_moveSpeed);
            _rigidBody.AddTorque(-_turnDirection * _turnSpeed);
        }
    }
}
