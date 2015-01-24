using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {
	public int value = 100;

	public const string NOTHING_STATE = "NOTHING_STATE";
	public const string FLAMINGO_STATE = "FLAMINGO_STATE";
	public const string FOX_STATE = "FOX_STATE";

	public Material[] materials;
	private Transform glowCube;

	public string currentState = NOTHING_STATE;
	// Use this for initialization
	void Start () {
		int chosenState = Random.Range(0, 3);
		switch(chosenState)
		{
		case 0:
			currentState = NOTHING_STATE;

			break;
		case 1:
			currentState = FLAMINGO_STATE;
			break;
		case 2:
			currentState = FOX_STATE;
			break;
		}

		glowCube = this.transform.FindChild ("GlowCube");
		glowCube.renderer.material = materials [chosenState];
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log (other.name);

		if(other.name.Equals("Fox") && currentState == FOX_STATE)
		{
			Debug.Log("Fox Ding!");
			GlobalVar.Instance.PLAYER_SCORE_1 += value;
			other.transform.GetComponent<PlayerController>().playPickupSound();
			Destroy(this.gameObject);
		}
		else if (other.name.Equals("Flamingo") && currentState == FLAMINGO_STATE)
		{
			Debug.Log("Flamingo Ding!");
			GlobalVar.Instance.PLAYER_SCORE_2 += value;
			other.transform.GetComponent<PlayerController>().playPickupSound();
			Destroy(this.gameObject);
		}

		if(GlobalVar.Instance.PLAYER_SCORE_1 == GlobalVar.Instance.MAX_PICKUPS*value || 
		   GlobalVar.Instance.PLAYER_SCORE_2 == GlobalVar.Instance.MAX_PICKUPS*value)
		{
			GlobalVar.Instance.WINNER = other.name;
			Application.LoadLevel(2);
		}
	}
}
