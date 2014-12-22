using UnityEngine;
using System.Collections;

public class RotateGear : MonoBehaviour {

	private float z = 0.0f;
	private float y = 0.0f;
	public float smoothing = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		z += Time.deltaTime * smoothing;
		y += Time.deltaTime * smoothing;
		transform.eulerAngles = new Vector3 (0,0,z);
	
	}
}
