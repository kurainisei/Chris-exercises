using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {
	public Transform target;
	public float positionDamping;
	public float rotationDamping;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position=Vector3.Lerp(transform.position, target.position, positionDamping);
		transform.rotation=Quaternion.Lerp (transform.rotation, target.rotation,rotationDamping);	
	}
}
