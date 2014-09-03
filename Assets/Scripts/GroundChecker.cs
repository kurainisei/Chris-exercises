using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

	public float checkerRadius;
	public LayerMask groundLayer;

	[System.NonSerialized]
	public bool isGrounded=false;


	
	// Update is called once per frame
	void Update () {
		isGrounded=Physics2D.OverlapCircle(transform.position, checkerRadius, groundLayer);
		Debug.Log (isGrounded);
	}
}
