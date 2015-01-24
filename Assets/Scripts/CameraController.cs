﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private float timeLeft;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI () {
		// Make a background box
		GUI.Box (new Rect (0, 0, 150, 25), "Player 1 Score: " + GlobalVar.Instance.PLAYER_SCORE_1);
		GUI.Box (new Rect (Screen.width - 150, 0, 150, 25), "Player 2 Score: " + GlobalVar.Instance.PLAYER_SCORE_2);

		
		timeLeft = 90f;
		if (timeLeft > 0) 
		{
			Debug.Log (timeLeft);
			timeLeft = (GlobalVar.Instance.MAX_PLAY_TIME - (int)(Time.timeSinceLevelLoad * 10) / 10f);
			Debug.Log (GlobalVar.Instance.MAX_PLAY_TIME);
		}
		else
			Application.LoadLevel (2);

		GUI.Box (new Rect ((Screen.width - 150)/2 , 0, 150, 25), "Time: " + timeLeft);
//		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
//		GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
	}
}
