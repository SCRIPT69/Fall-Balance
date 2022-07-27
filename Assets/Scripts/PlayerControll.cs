using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private GameObject _camera;
    private Rigidbody _playerRigidbody;
    private Movement _movement;
    private float _speed = 7;
    [SerializeField] Joystick _joystick;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
        _camera = GameObject.Find("Main Camera");
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ControllPlayerMovement();
    }

    void ControllPlayerMovement()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = _joystick.Horizontal;
        float verticalInput = _joystick.Vertical;
        _movement.AddForce(_camera.transform.forward * verticalInput * _speed);
        _movement.AddForce(_camera.transform.right * horizontalInput * _speed);
        //_playerRigidbody.AddForce(_camera.transform.forward * verticalInput * _speed);
        //_playerRigidbody.AddForce(_camera.transform.right * horizontalInput * _speed);
    }
}
