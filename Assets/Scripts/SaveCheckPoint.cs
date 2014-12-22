using UnityEngine;
using System.Collections;

public class SaveCheckPoint : MonoBehaviour {
	Director direct;
	// Use this for initialization
	void Start () {
		direct = GameObject.FindGameObjectWithTag ("Director").GetComponent<Director> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			if(Input.GetButtonDown("Interact"))
			{ 
				direct.SaveCheckpoint();
			gameObject.SetActive(false);
			}
		}

	}
}
