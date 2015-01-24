using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {
	public int value = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log (other.name);

		if(other.name.Equals("Player1"))
			GlobalVar.Instance.PLAYER_SCORE_1 += value;
		else
			GlobalVar.Instance.PLAYER_SCORE_2 += value;

		Destroy(this.gameObject);
	}
}
