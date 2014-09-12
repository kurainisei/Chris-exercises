using UnityEngine;
using System.Collections;

public class Buoyancy : MonoBehaviour {
	public float waterLevel;
	public float floatingForce;

	
	void FixedUpdate () {
		if (transform.position.y<waterLevel){
			rigidbody.AddForce(Vector3.up*floatingForce, ForceMode.Acceleration);
			rigidbody.drag=1;
		}
		else
			rigidbody.drag=0.1f;
	}
}
