using UnityEngine;
using System.Collections;

public class GlobalVar : Singleton<GlobalVar> {

	public float PLAYER_SCORE_1 = 0f;
	public float PLAYER_SCORE_2 = 0f;
	public int MAX_PICKUPS = 5;
	public float MAX_DIST = 30f;
	public float PLAYER_SPEED = 15f;
	public float MAX_PLAY_TIME = 90f;
	public float PLAYER_ROTATE_SMOOTH = 10f;
}
