﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed;
	public float jumpForce;



	private float _movement;
	private float _deadZone;
	private GroundChecker _checker;
	private Transform _pogoStick;
	private bool _isPogoActive=false;
	private bool _isJumping =false;
	private float _jumpSpeedLimit;


	// Use this for initialization
	void Start () {
		_deadZone = 0.01f;
		_checker = GetComponentInChildren<GroundChecker>();
		_jumpSpeedLimit = Physics2D.gravity.y/10;
		//cache and deactivate pogo stick
		_pogoStick = transform.Find("PogoStick");
		_pogoStick.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		_movement = Input.GetAxis("Horizontal");
		Debug.Log (Input.GetAxis("Vertical"));
		//convert analog input to digital
		if (_movement<_deadZone&&_movement>-_deadZone) 
			_movement=0;
		else 
			_movement = Mathf.Sign(_movement);

		//jump mechanic
		if (_checker.isGrounded&&Input.GetButtonDown("Jump"))
		{
			//start jumping
			_isJumping=true;
			rigidbody2D.AddForce(new Vector2 (0,jumpForce), ForceMode2D.Impulse);
		}

		//reduce jump velocity if is jumping and Jump is released
		if (_isJumping&&!Input.GetButton("Jump")&&rigidbody2D.velocity.y>_jumpSpeedLimit)
		{
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,_jumpSpeedLimit);
		}

		//set _isJumping to false if the character is falling
		if (_isJumping==true&&_checker.isGrounded==false&&rigidbody2D.velocity.y<0) _isJumping=false;

		Debug.Log (_isJumping);

		//activate and deactivate pogo
		if (Input.GetButton("Fire1")&&(Input.GetAxis("Vertical")< -_deadZone)&&_checker.isGrounded==false)
		{
			_pogoStick.gameObject.SetActive(true);
			_isPogoActive=true;
		}

		if (_isPogoActive&&Input.GetButtonUp("Fire1"))
		{
			_pogoStick.gameObject.SetActive(false);
			_isPogoActive=false;
		}


		//Debug.Log(rigidbody2D.velocity.x);
	}

	void FixedUpdate()
	{
		if (_movement==0&&rigidbody2D.velocity.x!=0)
			rigidbody2D.velocity=new Vector2 (0, rigidbody2D.velocity.y);
		else
			rigidbody2D.velocity=new Vector2 (speed*_movement, rigidbody2D.velocity.y);
	}

}
