using UnityEngine;
using System.Collections;

public class ControlOtherElevators : MonoBehaviour {
	public GameObject ObjectToBeActivated;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetButtonDown("Interact") && col.tag == "Player")
		{
			print ("Add a sound here");
			ObjectToBeActivated.SendMessage("Activate",col.gameObject);
			//HitSwitch hitSwitch = gameObject.GetComponent<HitSwitch>();
			//hitSwitch.enabled = false;
			//BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
			//box.enabled = false;
			gameObject.GetComponent<ControlOtherElevators>().enabled = false;
			
			
			
		}
	}
}
