using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private int points = 0;
    public Text pointsLabel;

    public MathController mathController;
    
	// Use this for initialization
	void Start () {
        pointsLabel.text = points.ToString();
                // Use this for initialization        mathController.setupQuestion();

    }

    public IEnumerator resetLevel()    {        yield return new WaitForSeconds(1);        mathController.setupQuestion();    }

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
}
