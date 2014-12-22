using UnityEngine;
using System.Collections;

public class PositionObjecToBtmRightScr : MonoBehaviour {
	Vector3 positionPlace;
	// Use this for initialization
	void Start () {
		Camera cam = Camera.main;
		positionPlace = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth,0,0));
		transform.position = positionPlace;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
