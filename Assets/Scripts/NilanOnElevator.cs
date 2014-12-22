using UnityEngine;
using System.Collections;

public class NilanOnElevator : MonoBehaviour {
	public bool NilanIsOnThisElevator = false;
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player")
			NilanIsOnThisElevator = true;
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player")
			NilanIsOnThisElevator = false;
	}
}
