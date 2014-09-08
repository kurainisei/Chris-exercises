using UnityEngine;
using System.Collections;

public class EngineControl : MonoBehaviour {
	public bool isOn=false;
	public string operateKey;
	public float engineSpeed;
	private Transform _boat;
	private Rigidbody _boatRB;
	// Use this for initialization
	void Start () {
		_boat = transform.parent;
		_boatRB = _boat.rigidbody;
	}

	void Update()
	{
		if (Input.GetButton(operateKey))
			isOn=true;
		else
			isOn=false;
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (isOn)
		{
			_boatRB.AddForceAtPosition(transform.forward*engineSpeed,transform.position);
		}
	}
}
