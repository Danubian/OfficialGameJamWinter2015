using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class StartCamera : MonoBehaviour {

	bool hasButtonPressed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying && hasButtonPressed) {
			Application.LoadLevel(1);
		}
	}

	float width = 150;
	float height = 25;

	void OnGUI() {
		if(GUI.Button (new Rect ((Screen.width - width)/2, (Screen.height - height)/2, width, height), "Click to Continue")) {
			hasButtonPressed = true;
			audio.Play();
		}
	}
}
