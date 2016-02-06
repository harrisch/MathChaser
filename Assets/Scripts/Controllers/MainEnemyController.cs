using UnityEngine;
using System.Collections;

public class MainEnemyController : MonoBehaviour {
	public delegate void OnPlayerHitsMainEnemyEvent();
	public event OnPlayerHitsMainEnemyEvent OnPlayerHitsMainEnemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {		
		if (other.gameObject.tag == "Player") {
			OnPlayerHitsMainEnemy();
		}
	}
}
