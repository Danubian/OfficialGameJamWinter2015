using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject otherPlayer;
	private PlayerController other;
	
	public string forward;
	public string backward;
	public string left;
	public string right;


	private Vector3 velocity = Vector3.zero;
	private Vector3 displacement;

	private Transform playerMesh;

	// Use this for initialization
	void Start () {
		other = otherPlayer.GetComponent<PlayerController> ();
		playerMesh = this.transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () {
		move();
	}

	public bool isInRange() {
		Vector3 pos1 = this.transform.position + this.velocity;
		Vector3 pos2 = other.transform.position + other.velocity;
		displacement = pos1 - pos2;
		float distance = displacement.magnitude;
		return distance < GlobalVar.Instance.MAX_DIST;
	}

	private float lastRotation;
	public void move()
	{
		float speedX = getSpeedX()*Time.deltaTime;
		float speedY = getSpeedY()*Time.deltaTime;

		velocity = new Vector3 (speedX, 0f, speedY);

		if (!isInRange ()) {
			Debug.Log("Range Ding!");
			if((displacement.x > 0 || speedX > 0) ||
			   (displacement.x < 0 || speedX < 0))
			{
				speedX = 0;
			}

			if((displacement.y > 0 || speedY > 0) ||
			   (displacement.y < 0 || speedY < 0))
			{
				speedY = 0;
			}
		}
		if(speedX != 0 || speedY != 0)
		{
			float rotation = Vector3.Angle (new Vector3(1, 0, 0), new Vector3 (speedX, 0, speedY));
			if(speedY > 0)
				rotation *= -1;

			playerMesh.eulerAngles = Vector3.Lerp(playerMesh.eulerAngles, new Vector3(0, rotation, 0), GlobalVar.Instance.PLAYER_ROTATE_SMOOTH * Time.deltaTime);
				

			lastRotation = rotation;

			this.transform.Translate(speedX, 0f, speedY);
		}


	}

	public float getSpeedX()
	{
		float result = 0f;

		if(Input.GetKey (forward)) 
		{
			result += GlobalVar.Instance.PLAYER_SPEED;
		}

		if (Input.GetKey (backward)) 
		{
			result -= GlobalVar.Instance.PLAYER_SPEED;
		}
		return result;
	}

	public float getSpeedY()
	{
		float result = 0f;
		if(Input.GetKey (left)) 
		{
			result += GlobalVar.Instance.PLAYER_SPEED;
		}
		
		if (Input.GetKey (right)) 
		{
			result -= GlobalVar.Instance.PLAYER_SPEED;
		}
		return result;
	}
}
