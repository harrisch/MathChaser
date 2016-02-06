using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public delegate void OnPlayerHitsEnemyEvent();
	public event OnPlayerHitsEnemyEvent OnPlayerHitsEnemy;

	public int speed = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-speed * Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {		
		if (other.gameObject.tag == "Player") {
			OnPlayerHitsEnemy();
		}
	}
}
