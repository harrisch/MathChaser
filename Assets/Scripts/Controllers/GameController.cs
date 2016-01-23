using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private int points = 0;
    public Text pointsLabel;
    
	// Use this for initialization
	void Start () {
        pointsLabel.text = points.ToString(); ;
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
}
