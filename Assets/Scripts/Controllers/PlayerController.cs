using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D body;

	public int jumpStrength = 100;

	public int stumbleStrength = 100;

	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
				
	}

	public void jump() {
		body.AddForce (new Vector2 (0, jumpStrength));
	}

	public void stumble() {
		body.AddForce (new Vector2 (-stumbleStrength, 0));
	}

	public void forward() {
		body.AddForce (new Vector2 (80, 0));
	}
}
