using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float yOffset = 0.5f;
	public GameObject playerobject = null;
	public float cameraTrackingSpeed =  0.2f;
	private Vector3 lastTargetPosition = Vector3.zero;
	private Vector3 currTargetPosition = Vector3.zero;
	private float currLerpDistance = 0.0f;
	private Director director;

	void Awake()
	{
		Vector3 correctedpos = playerobject.transform.position;
		correctedpos.z = -10;
		transform.position = correctedpos;

	}
	// Use this for initialization
	void Start () {
		//set the initial camera position to prevent any weird jerking

		Vector3 playerPos = playerobject.transform.position;
		Vector3 cameraPos = transform.position;
		cameraPos.y += yOffset;
		Vector3 startTarPos = playerPos; 

		//set the z to the same as the camera so it does not move
		startTarPos.z = cameraPos.z;
		lastTargetPosition = startTarPos;
		currTargetPosition = startTarPos;
		currLerpDistance = 1.0f;


		//instantiate the director object

		GameObject obj = GameObject.FindGameObjectWithTag ("Director");
		if (obj == null)
						Debug.Log ("cant find the director");
				else
						director = obj.GetComponent<Director> ();

	}

	
	
	// Update is called once per frame
	void Update () {
	
	}



	void LateUpdate()
	{
		//update based on our current state
		onStateCycle ();

		//continue to move to the current target position
		currLerpDistance += cameraTrackingSpeed;
		transform.position = Vector3.Lerp (lastTargetPosition, currTargetPosition, currLerpDistance);



	}


	//every cycle of the engine, process the current state
	void onStateCycle()
	{
		/**
		 * we use the player state to determine the current action that the camera should take. 
		 * 
		 * 
		 * 
		 * **/
		if (!director.isPlayerDead())
		    trackPlayer();

	}

	void trackPlayer()
	{
		//get and store the current camera position, and the current player position in world coordinates
		Vector3 currCamPos = transform.position;
		currCamPos.y += yOffset;
		Vector3 currPlayerPos = playerobject.transform.position;

		if (currCamPos.x == currPlayerPos.x && currCamPos.y -yOffset == currPlayerPos.y) {
				
		//positions are the same- tell the camera not to move, then abort
			currLerpDistance = 1f;
			lastTargetPosition = currCamPos ;
			currTargetPosition = currCamPos;
			return;
		
		}

		//reset the travel distance for the lerp
		currLerpDistance = 0f;

		//store the current target position so we can lerp from it
		lastTargetPosition = currCamPos;

		//store the new target position
		currTargetPosition = currPlayerPos;

		//change the z position fo the target to the same as the current
		//we don't want that to change
		currTargetPosition.z = currCamPos.z;




	}
	void stopTrackingPlayer()
	{
		//set the target positioning to the camera's current position to stop its movement in its tracks

		Vector3 currCamPos = transform.position;
		currCamPos.y += yOffset;
		currTargetPosition = currCamPos; 
		lastTargetPosition = currCamPos;
		//also set the lerp progress distance to 1.0f, which will tell the lerping that it is finished
		//since we set  the target positioning to the camera's current position, the camera will just lerp //
		//to its current spot and stop there
		currLerpDistance = 1.0f;



	}
}
