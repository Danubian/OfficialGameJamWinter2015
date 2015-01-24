﻿using UnityEngine;
using System.Collections;

public class GlobalVar : Singleton<GlobalVar> {

	public float PLAYER_SCORE_1 = 0f;
	public float PLAYER_SCORE_2 = 0f;
	public float MAX_DIST = 30f;
	public float PLAYER_SPEED = .2f;
	public float MAX_PLAY_TIME = 90f;
}
