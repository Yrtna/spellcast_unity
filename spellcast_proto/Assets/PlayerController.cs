using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
    public float speed;

    // Start is called before the first frame update
    private int _groundTargetingLayer;

    private float _hInput;
    private float _vInput;

    private Vector3 _move;

    private CharacterController _controller;

    void Start()
    {
        _hInput = 0f;
        _vInput = 0f;
        _groundTargetingLayer = LayerMask.GetMask("GroundTargeting");
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // _hInput = Input.GetAxis("Horizontal") * speed;
        // _vInput = Input.GetAxis("Vertical") * speed;

        // this.transform.Translate(horizontal, 0, vertical);
        
        _move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        _controller.SimpleMove(_move * (Time.deltaTime * speed));
        // var position = this.transform.position;
        // transform.position = new Vector3(position.x + _hInput * Time.deltaTime, position.y,
        //     position.z + _vInput * Time.deltaTime);
    }
    */

    public float Speed = 10f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 10f;
    public LayerMask Ground;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;

    private Vector3 MouseVec;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground,
            QueryTriggerInteraction.Ignore);
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            var direction = (MouseVec - this.transform.position).normalized;
            _body.AddForce(direction * DashDistance, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        // _body.MovePosition(_body.position + _inputs * (Speed * Time.fixedDeltaTime));
        MyMovePosition(_body.position + _inputs * (Speed * Time.fixedDeltaTime));
    }

    private void LateUpdate()
    {
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, Ground))
        {
            MouseVec = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(MouseVec);
        }
    }

    void MyMovePosition(Vector3 destinationPosition)
    {
        var oldVel = _body.velocity;
        var delta = destinationPosition - _body.position;
        var vel = delta / Time.fixedDeltaTime;

        //gravity
        vel.y = oldVel.y;

        //Slow velocity on collision
        vel.x = Mathf.Abs(oldVel.x) > Mathf.Abs(vel.x) ? oldVel.x : vel.x;
        vel.z = Mathf.Abs(oldVel.z) > Mathf.Abs(vel.z) ? oldVel.z : vel.z;

        _body.velocity = vel;
    }
}