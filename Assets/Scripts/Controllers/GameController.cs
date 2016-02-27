using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private int points = 0;
    
    public Text pointsLabel;
	public Text gameOverLabel;

    public MathController mathController;
	public EnemySpawnController spawnController;

	public GameObject mainEnemy;
	public GameObject player;
    
	public float lastHitTime = 0;

	private Queue enemies = new Queue();


	// Use this for initialization
	void Start () {
		gameOverLabel.enabled = false;
        pointsLabel.text = points.ToString();
        
        // Use this for initialization
		resetLevel();

		// Set event handlers
		mathController.OnQuestionAnswered += onQuestionAnsweredEvent;
		
		MainEnemyController mainEnemyController = mainEnemy.GetComponent<MainEnemyController>();
		mainEnemyController.OnPlayerHitsMainEnemy += onPlayerHitsMainEnemyEvent;
    }

    public int Points 
    {
        get {
            return points;
        }
        set {
            points = value;
        }
    }
		
    public void resetLevel() {      		
        mathController.setupQuestion();
		spawnEnemy();
    }

    // Update is called once per frame
    void Update () {
        pointsLabel.text = points.ToString();        
	}

	private void spawnEnemy() {
		GameObject enemy = spawnController.spawn ();
		EnemyController enemyController = enemy.GetComponent<EnemyController> ();
		enemyController.OnPlayerHitsEnemy += onPlayerHitsEnemyEvent;
		enemyController.OnEnemyExplode += onEnemyExplodeEvent;

		enemies.Enqueue (enemy);
	}



	/*************** EVENTS **************/

	public void onQuestionAnsweredEvent(bool correct) {
		if (correct) {
			points = points + 100;
			player.GetComponent<PlayerController> ().jump (80);
		} else { 
			points = points - 100;
			player.GetComponent<PlayerController> ().stumble (80);
		}
	}

	public void onPlayerHitsMainEnemyEvent() {
		gameOverLabel.enabled = true;
		Time.timeScale = 0;
	}

	public void onPlayerHitsEnemyEvent() {
		if (Time.time - lastHitTime > 1) {
			player.GetComponent<PlayerController> ().stumble (PlayerController.stumbleStrength);
			lastHitTime = Time.time;
		}
	}

	public void onEnemyExplodeEvent(GameObject exploded) {
		GameObject enemy = (GameObject)enemies.Peek ();
		if (exploded == enemy) {
			enemies.Dequeue ();		
			resetLevel ();	
		}	

	}
}
