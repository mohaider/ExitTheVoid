using UnityEngine;
using System.Collections;

public class ActivateLadder : MonoBehaviour {

	public float yTransform = -22f;
	private bool isActivated = false;
	public float slowdownLerp = 0.2f;
	private Vector2 endposition;
	private float endYPosition;

	// Use this for initialization
	void Start () {
		 endposition = new Vector2 (transform.position.x, transform.position.y + yTransform);
		endYPosition = endposition.y + 0.2f;
		print (endYPosition);
	}
	
	// Update is called once per frame
	void Update () {

		if (isActivated)
			transform.position = Vector2.Lerp (transform.position, endposition, Time.deltaTime * slowdownLerp);

		if (transform.position.y < endYPosition)
						//isActivated = false;
						print ("Stopping elevator ");
		//print (transform.position.y);
	}



	void Activate()
	{
		print ("ladder activated");
		isActivated = true;
	}
}
