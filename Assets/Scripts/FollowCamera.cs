using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public GameObject cam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = new Vector2 (cam.transform.position.x, cam.transform.position.y);
		transform.position = pos;
	}
}
