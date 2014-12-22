using UnityEngine;
using System.Collections;

public class ActivateDeactivatePuzzle : MonoBehaviour {
	public GameObject piece;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate()
	{
		piece.collider2D.enabled =(true);


	}

	public void Deactivate()
	{

		piece.collider2D.enabled =(false);
	}
}
