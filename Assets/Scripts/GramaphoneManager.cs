using UnityEngine;
using System.Collections;

public class GramaphoneManager : MonoBehaviour {
	private bool isPowered = false;
	private string message = "You try activating the gramophone but it doesn't seem to start.";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {




	
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.name == "Player") {
			if (Input.GetButtonDown("Interact"))
			    {
			if (!isPowered)
				//trigger message on screen
				print (message);
			if (isPowered)
					print ("play a snippet of moonlight sonata");
			}
		
		}


	}
}
