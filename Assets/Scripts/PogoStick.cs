using UnityEngine;
using System.Collections;

public class PogoStick : MonoBehaviour {
	public float pogoForce;
	private Transform _parent;

	// Use this for initialization
	void Start () 
	{
		_parent = transform.parent;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		_parent.rigidbody2D.AddForce (new Vector2 (0,pogoForce), ForceMode2D.Impulse);
		if (collision.gameObject.tag=="Breakable")
		{
			Destroy(collision.gameObject);
		}
	}
}
