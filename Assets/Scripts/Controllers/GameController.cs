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

	// Use this for initialization
	void Start () {
		gameOverLabel.enabled = false;
        pointsLabel.text = points.ToString();
        
        // Use this for initialization
		resetLevel();

		mathController.OnQuestionAnswered += onQuestionAnsweredEvent;

		MainEnemyController mainEnemyController = mainEnemy.GetComponent<MainEnemyController>();
		mainEnemyController.OnPlayerHitsMainEnemy += onPlayerHitsMainEnemyEvent;



    }
		
    public void resetLevel()
    {      
		spawnController.destroy ();

        mathController.setupQuestion();
		GameObject enemy = spawnController.spawn ();
		EnemyController enemyController = enemy.GetComponent<EnemyController> ();
		enemyController.OnPlayerHitsEnemy += onPlayerHitsEnemyEvent;
    }

    // Update is called once per frame
    void Update () {
        pointsLabel.text = points.ToString();
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

	public void onQuestionAnsweredEvent(bool correct) {
		if (correct) {
			points = points + 100;
			player.GetComponent<PlayerController> ().jump ();
			player.GetComponent<PlayerController> ().forward ();
		} else { 
			points = points - 100;
			player.GetComponent<PlayerController> ().stumble ();
		}
			
		resetLevel ();
	}

	public void onPlayerHitsMainEnemyEvent() {
		gameOverLabel.enabled = true;
	}

	public void onPlayerHitsEnemyEvent() {
		if (Time.time - lastHitTime > 1) {
			player.GetComponent<PlayerController> ().stumble ();
			lastHitTime = Time.time;
		}
	}
}
