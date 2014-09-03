using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed;
	public float jumpForce;
	private float _movement;
	private float _deadZone;
	private GroundChecker _checker;
	// Use this for initialization
	void Start () {
		_deadZone = 0.1f;
		_checker = GetComponentInChildren<GroundChecker>();
	}
	
	// Update is called once per frame
	void Update () {
		_movement = Input.GetAxis("Horizontal");

		//convert analog input to digital
		if (_movement<_deadZone&&_movement>-_deadZone) 
			_movement=0;
		else 
			_movement = Mathf.Sign(_movement);

		//jump mechanics
		if (_checker.isGrounded&&Input.GetButtonDown("Jump"))
		{
			rigidbody2D.AddForce(new Vector2 (0,jumpForce), ForceMode2D.Impulse);
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
