using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public delegate void OnPlayerHitsEnemyEvent();
	public delegate void OnEnemyExplodeEvent(GameObject exploded);
	public event OnPlayerHitsEnemyEvent OnPlayerHitsEnemy;
	public event OnEnemyExplodeEvent OnEnemyExplode;

	public int speed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moveEnemy();
	}

	void OnTriggerEnter2D(Collider2D other) {		
		if (other.gameObject.tag == "Player") {
			OnPlayerHitsEnemy();
			explode();
		} else if (other.gameObject.tag == "MainEnemy") {
			explode();
		}
	}

	void moveEnemy() {
		transform.Translate (-speed * Time.deltaTime, 0, 0);
	}

	void explode() {
		OnEnemyExplode(gameObject);
		Destroy (gameObject);
	}
}
