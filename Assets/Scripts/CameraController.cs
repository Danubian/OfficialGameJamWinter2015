using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float MAX_TIME = 30;
	private float timeLeft;
	private int counter = 0;

	// Use this for initialization
	void Start () {
		timeLeft = MAX_TIME;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI () {
		// Make a background box
		GUI.Box (new Rect (0, 0, 150, 25), "Player 1 Score: " + counter);
		GUI.Box (new Rect (Screen.width - 150, 0, 150, 25), "Player 2 Score: " + counter);


		if(timeLeft > 0)
			timeLeft = (MAX_TIME - (int)(Time.timeSinceLevelLoad*10)/10f);

		GUI.Box (new Rect ((Screen.width - 150)/2 , 0, 150, 25), "Time: " + timeLeft);
//		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
//		GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
		counter++;
	}
}
