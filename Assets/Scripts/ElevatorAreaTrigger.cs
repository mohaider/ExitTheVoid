using UnityEngine;
using System.Collections;

public class ElevatorAreaTrigger : MonoBehaviour {
	public GameObject camera;
	bool ResetZoomFactor = false;
	float originalZoomPos = 1f;
	private Director director;

	void Start()
	{
		GameObject temp = GameObject.FindGameObjectWithTag ("Director");
		if (ErrorWindow<ElevatorAreaTrigger>.CanBeAssigned (temp, this, "Director"))
						director = temp.GetComponent<Director> ();

		}
	void Update()
	{
		if (director.isPlayerDead()) {
			ResetZoomFactor = true;
			
			//GetComponent<ElevatorAreaCamera> ().enabled = true;
			resetCamPosition();
		
		}
	}

	void LateUpdate()
	{


		if (ResetZoomFactor) { //quickly reset zoom position back
			float currentZoom = camera.GetComponent<tk2dCamera>().ZoomFactor;
			currentZoom = Mathf.Lerp(currentZoom,originalZoomPos,Time.deltaTime *2.0f); //quickly zoom back
			camera.GetComponent<tk2dCamera>().ZoomFactor =currentZoom;
			if (currentZoom >= originalZoomPos)
				ResetZoomFactor = true;
			
			
		}

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{ 
			ResetZoomFactor = false;
			GetComponent<ElevatorAreaCamera> ().enabled = true;	
			setCamPosition();

		}
			//print ("Now entering area, zoom in the camera and bring down the textures");

		
	}


	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player") {
			ResetZoomFactor = true;

			//GetComponent<ElevatorAreaCamera> ().enabled = true;
			resetCamPosition();
		}
	

	}


	void setCamPosition()
	{
		camera.GetComponent<CameraFollow> ().enabled = false;
		gameObject.GetComponent<ElevatorAreaCamera> ().enabled = true;
		//lerp towards middlePoint
		;
	}
	void resetCamPosition()
	{
		gameObject.GetComponent<ElevatorAreaCamera> ().enabled = false;
		camera.GetComponent<CameraFollow> ().enabled = true;

	}

}
