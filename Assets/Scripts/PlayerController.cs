using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float _moveSpeed = 5;
    private float _turnSpeed = 10;

    private Rigidbody _playerRigidbody;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");  
    }

    private void FixedUpdate()
    {
        _moveDirection = new Vector3(_horizontalInput, 0, _verticalInput);
        _playerRigidbody.velocity = _moveDirection.normalized * _moveSpeed;

        if (_moveDirection != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, _moveDirection, Time.fixedDeltaTime * _turnSpeed);
        }
    }

    public void UpdatePlayerSpeed(float massToAdd)
    {
        _playerRigidbody.mass += massToAdd;
        _moveSpeed = 500 / _playerRigidbody.mass;
    }
}
