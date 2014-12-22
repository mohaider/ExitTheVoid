using UnityEngine;
using System.Collections;

public class DisableCamFollow : MonoBehaviour {

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			//disable camera following
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled =false;


		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			//disable camera following
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled =true;
			
			
		}

	}
}
