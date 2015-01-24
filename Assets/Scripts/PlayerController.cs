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

	// Use this for initialization
	void Start () {
		other = otherPlayer.GetComponent<PlayerController> ();
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

	public void move()
	{
		float speedX = getSpeedX();
		float speedY = getSpeedY();

		velocity = new Vector3 (speedX, 0f, speedY);

		if (!isInRange ()) {
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

		this.transform.Translate (speedX, 0f, speedY);
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
