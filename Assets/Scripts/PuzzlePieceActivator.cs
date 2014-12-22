using UnityEngine;
using System.Collections;

public class PuzzlePieceActivator : MonoBehaviour {
	public GameObject eventToActivate;
	private HintBoxController hintbox;
	private SoundDirector soundDirector;

	void Awake()
	{
		print ("puzzle inventory awake");
		GameObject temp = GameObject.FindGameObjectWithTag ("HintBox");

		if( ErrorWindow<PuzzlePieceActivator>.CanBeAssigned (temp,this, "HintBox")) 
			hintbox=temp.GetComponent<HintBoxController> ();
		GameObject soundDirObj = GameObject.FindGameObjectWithTag ("SoundDirector");
		if (soundDirObj != null)
			soundDirector = soundDirObj.GetComponent<SoundDirector> ();
		else
			Debug.Log ("Cannot find the SoundDirector!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPickup()
	{
		if (eventToActivate != null)
			eventToActivate.SendMessage ("PuzzlePiecePickedUp");

		//disable the hintbox for this puzzlePiece
		soundDirector.play (SoundDirector.Mode.pickup);
		hintbox.UseMessageBox (this.gameObject, HintBoxController.Mode.permanentlyDeactivateBox, "");



	}
}
