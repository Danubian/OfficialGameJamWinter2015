using UnityEngine;
using System.Collections;

public class Center : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;
	public Vector3 normal;
	public float distance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player1.transform.position, player2.transform.position);
		normal = (player1.transform.position + player2.transform.position) / 2;
		this.transform.position = normal;
	}
}
