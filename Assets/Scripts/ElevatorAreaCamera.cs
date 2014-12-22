using UnityEngine;
using System.Collections;

public class ElevatorAreaCamera : MonoBehaviour {

	public GameObject camera;
	public GameObject middlePostion; 
	public float CameraZoom = 0.25f;
	public float originaCamZoom = 1f;

	Vector3 prevPos;
	tk2dCamera cam;
	float LerpSpeed = 0.5f;
	bool lerpTowardsMiddle  = false;
	float zoomFactor = 0f;
	bool stopMoving = false;




	void Start()
	{
		cam = camera.GetComponent<tk2dCamera> ();
		zoomFactor = originaCamZoom;

	}
	void OnEnable()
	{
		zoomFactor = originaCamZoom;
		stopMoving = false;
		}
	// Update is called once per frame
	void Update () {
		if (!stopMoving) 
		{
			zoomFactor = Mathf.Lerp (zoomFactor, CameraZoom, Time.deltaTime * LerpSpeed);
			cam.ZoomFactor = zoomFactor;
			camera.transform.position = Vector3.Lerp (camera.transform.position, middlePostion.transform.position, Time.deltaTime * LerpSpeed);
//			if (camera.transform.position.x == middlePostion.transform.position.x) //to prevent weird camera jerking motions
//				stopMoving = true;
		}


	}

	void BringDownTextures()
	{
		
	}
	
	void BringUpTextures()
	{
		
		
	}




}
