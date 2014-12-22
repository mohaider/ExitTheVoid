using UnityEngine;
using System.Collections;

public class TriggerMusicalArea : MonoBehaviour {

	public ElevatorAreaTrigger trig;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
						trig.enabled = true;


	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player")
			trig.enabled = false;
		
		
	}
}
