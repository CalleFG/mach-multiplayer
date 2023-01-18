using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    private float _playerSpeed = 10.0f;
    private float _diagonalSpeedLimit = 0.7f;
    private Transform _body;
    
    void Start()
    {
        _body = transform;
    }

    void Update()
    {
        InputCollection();
        Movement();
    }
    
    private void InputCollection()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    private void Movement()
    {
        float horizontalSpeed = _horizontal * _playerSpeed;
        float verticalSpeed = _vertical * _playerSpeed;

        if (_horizontal != 0 && _vertical != 0)
        {
            _body.position += new Vector3(
                horizontalSpeed * _diagonalSpeedLimit * Time.deltaTime,
                verticalSpeed * _diagonalSpeedLimit * Time.deltaTime,
                0);
        }
        else
        {
            _body.position += new Vector3(
                horizontalSpeed * Time.deltaTime,
                verticalSpeed * Time.deltaTime,
                0);
        }
    }
}
