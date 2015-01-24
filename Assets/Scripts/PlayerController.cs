using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject otherPlayer;
	private PlayerController other;
	private float speed = .2f;
	
	public string forward;
	public string backward;
	public string left;
	public string right;

	private const float MAX_DIST = 20f;
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
		return distance < MAX_DIST;
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
			result += speed;
		}

		if (Input.GetKey (backward)) 
		{
			result -= speed;
		}
		return result;
	}

	public float getSpeedY()
	{
		float result = 0f;
		if(Input.GetKey (left)) 
		{
			result += speed;
		}
		
		if (Input.GetKey (right)) 
		{
			result -= speed;
		}
		return result;
	}
}
