using UnityEngine;
using System.Collections;

public class EngineControl : MonoBehaviour {
	public int isOn=0;
	public string operateKey;
	public string reverseKey;
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
			isOn=1;
		else if (Input.GetButton(reverseKey))
			isOn=-1;
		else
			isOn=0;
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (isOn==1)
		{
			_boatRB.AddForceAtPosition(transform.forward*engineSpeed,transform.position);
		}
		else if (isOn==-1)
		{
			_boatRB.AddForceAtPosition(-transform.forward*engineSpeed/5,transform.position);
		}
	}
}
