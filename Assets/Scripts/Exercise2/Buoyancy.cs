using UnityEngine;
using System.Collections;

public class Buoyancy : MonoBehaviour {
	public float waterLevel;
	public float floatingForce;

	private Transform _floatingLine;


	// Use this for initialization
	void Start () {
		_floatingLine = transform.Find ("floatingLine");
	}
	
	void FixedUpdate () {
		if (_floatingLine.position.y<waterLevel)
			rigidbody.AddForce(Vector3.up*floatingForce, ForceMode.Acceleration);
	}
}
