using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D body;

	public static int jumpStrength = 100;

	public static int stumbleStrength = 100;

	public static int forwardStrength = 80;

	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
				
	}

	public void jump(int strength) {
		body.AddForce (new Vector2 (0, strength));
	}

	public void stumble(int strength) {
		body.AddForce (new Vector2 (-strength, 0));
	}

	public void forward(int strength) {
		body.AddForce (new Vector2 (strength, 0));
	}
}
