using UnityEngine;
using System.Collections;

public class ZoomIntoScene : MonoBehaviour {

	public float zoomSpeed = 1.2f;
	public float lerpSpeed = 1.2f;

	public GameObject mainCam ;
	public GameObject target;
	private float prevZoom=1f;
	private float zoom = 7.61f;
	private Vector3 prevCamPos;
	private float prevZPos;
	public bool zoomIn = false;

	void OnEnable()
	{

		mainCam.GetComponent<CameraFollow> ().enabled = false;
		prevZoom = mainCam.GetComponent<tk2dCamera> ().ZoomFactor;
		prevZPos = mainCam.transform.position.z;
		mainCam.transform.position = target.transform.position + Vector3.forward*prevZPos;
		zoomIn = true;

	}

	// Update is called once per frame
	void Update () {
		if (zoomIn)
			ZoomIn ();

	
	}
	public void ZoomIn()
	{
		mainCam.GetComponent<tk2dCamera> ().ZoomFactor = Mathf.Lerp (mainCam.GetComponent<tk2dCamera> ().ZoomFactor, zoom, Time.deltaTime * zoomSpeed);
	}

	public void ResetZoom()
	{
		mainCam.GetComponent<CameraFollow> ().enabled = true;
		mainCam.GetComponent<tk2dCamera> ().ZoomFactor=prevZoom;
		zoomIn = false;
	}
}
