using UnityEngine;
using System.Collections;

public class ClimbThis : MonoBehaviour {
	public float climbingSpeed = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			print ("Player will try to climb");
			if (Input.GetButton("Vertical"))
			{
				float upOrDown = Input.GetAxis("Horizontal");
				col.transform.position = new Vector2(col.transform.position.x, col.transform.position.y + climbingSpeed*upOrDown);
			}


		}

	}
}
