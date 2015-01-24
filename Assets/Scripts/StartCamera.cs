using UnityEngine;
using System.Collections;

public class StartCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	float width = 150;
	float height = 25;

	void OnGUI() {
		if(GUI.Button (new Rect ((Screen.width - width)/2, (Screen.height - height)/2, width, height), "Click to Continue")) {
			Application.LoadLevel(1);
		}
	}
}
