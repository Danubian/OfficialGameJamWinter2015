using UnityEngine;
using System.Collections;

public class AreaController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.localScale = new Vector3(GlobalVar.Instance.MAX_DIST*60f/50f, 0.01f, GlobalVar.Instance.MAX_DIST*60f/50f);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.parent.GetComponent<Center> ().normal;
//		float dist = this.transform.parent.GetComponent<Center>().distance;
//		Color c = this.renderer.material.color;
//		c.a = 255 * (dist - PlayerController.MAX_DIST/2) / PlayerController.MAX_DIST/2;
//		Debug.Log (c);
//		this.renderer.material.color = c;
	}
}
