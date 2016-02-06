using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour {
	public GameObject enemyObject;
	public GameObject playerObject;

	public GameObject instantiated;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject spawn() {
		instantiated = (GameObject) Instantiate (enemyObject, new Vector3(playerObject.transform.position.x + 30, playerObject.transform.position.y, 0), Quaternion.identity);

		return instantiated;
	}

	public void destroy() {
		Destroy (instantiated);
	}
}
