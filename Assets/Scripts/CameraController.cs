using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private float timeLeft;
	private int counter = 0;

	// Use this for initialization
	void Start () {
		timeLeft = GlobalVar.Instance.MAX_TIME;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI () {
		// Make a background box
		GUI.Box (new Rect (0, 0, 150, 25), "Player 1 Score: " + GlobalVar.Instance.PLAYER_SCORE_1);
		GUI.Box (new Rect (Screen.width - 150, 0, 150, 25), "Player 2 Score: " + GlobalVar.Instance.PLAYER_SCORE_2);


		if (timeLeft > 0)
			timeLeft = (GlobalVar.Instance.MAX_TIME - (int)(Time.timeSinceLevelLoad * 10) / 10f);
		else
			Application.LoadLevel (2);

		GUI.Box (new Rect ((Screen.width - 150)/2 , 0, 150, 25), "Time: " + timeLeft);
//		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
//		GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
	}
}
