using UnityEngine;
using System.Collections;

public class killNilan : MonoBehaviour {

	public GameObject  director;
	public AudioClip deathSound;
	private int hasBeenKilledNTimes =0;
	private HintBoxController hintbox;


	void Awake () {
		GameObject temp = GameObject.FindGameObjectWithTag ("HintBox");
		if (ErrorWindow<killNilan>.CanBeAssigned (temp, this, "HintBox")) {
			hintbox = temp.GetComponent<HintBoxController> ();
			//	hintbox.AddObj(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D col) {

		if(col.gameObject.tag == "Player")
		{
			audio.clip = deathSound;
			audio.Play ();
			director.GetComponent<Director>().PlayerIsDead();
			hasBeenKilledNTimes++;
			if(hasBeenKilledNTimes ==1)
			{
				StartCoroutine("BeenKilledOnce");
;
			}

		}
	}

	IEnumerator BeenKilledOnce()
	{
		yield return new WaitForSeconds (3f); 
		hintbox.UseMessageBox (gameObject, HintBoxController.Mode.activateMessage, "Watch out for the spikes!");
		yield return new WaitForSeconds (3f);
			hintbox.UseMessageBox (gameObject, HintBoxController.Mode.permanentlyDeactivateBox, "Watch out for the spikes!");
		hasBeenKilledNTimes ++;
	}





}
