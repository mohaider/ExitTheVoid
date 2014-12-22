using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour {


	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetButtonDown("Interact"))
		    {
			Application.LoadLevel("Fin");

		}



	}
}
