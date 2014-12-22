using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzlePlatform : MonoBehaviour {
	List<GameObject> pieces;
	private int totalPiecesLeft =0;
	public AudioClip onPuzzlefit;
	private HintBoxController hintbox;
	private FlashingTextController flashText;
	public string hint ="Look like an unpainted canvas";
	private string pressE = "Press e";
	private SoundDirector soundDirector;
	private Director director;
	private bool hasSeenPressE =false;

	private bool hasInsertedFirstPuzzle =false;


	private bool onlyOneChild=false;



	// Use this for initialization
	void Awake () {
		GameObject soundDirObj = GameObject.FindGameObjectWithTag ("SoundDirector");
		if (soundDirObj != null)
			soundDirector = soundDirObj.GetComponent<SoundDirector> ();
		else
			Debug.Log ("Cannot find the SoundDirector!");

		GameObject directorObj = GameObject.FindGameObjectWithTag ("Director");
		if (directorObj != null)
			director = directorObj.GetComponent<Director> ();
		else
			Debug.Log ("Cannot find the SoundDirector!");
		
		



		pieces = new List<GameObject>();
		foreach (Transform child in transform)
		{

			if(child.tag == "hiddenPuzzlePieces")
				pieces.Add (child.gameObject);
		}
		totalPiecesLeft = pieces.Count;

		if (pieces.Count == 1)
			onlyOneChild = true;

		
		GameObject temp = GameObject.FindGameObjectWithTag ("HintBox");
		if (ErrorWindow<PuzzlePlatform>.CanBeAssigned (temp, this, "HintBox")) {
			hintbox = temp.GetComponent<HintBoxController> ();
			hintbox.AddObj(gameObject);
			}
		
		GameObject tempFlash = GameObject.FindGameObjectWithTag ("FlashingTextBox");
		if( ErrorWindow<PuzzlePlatform>.CanBeAssigned (tempFlash,this, "FlashingTextBox")) 
		{
			flashText=tempFlash.GetComponent<FlashingTextController> ();
			flashText.AddObj(gameObject);
		}
	}
	


	public void ActivatePiece(GameObject piece)
	{
		print ("checking to see  child!");
		hasSeenPressE=true;
		hasInsertedFirstPuzzle = true;
		print (pieces.Count);
		foreach (GameObject child in pieces) {
			print (child.name);
			if (piece.name == child.name)
			{
				print ("It is it's child!");
				child.GetComponent<SpriteRenderer>().enabled = true;//set the sprite renderer state to active
				totalPiecesLeft--;
				audio.clip  = onPuzzlefit;
				audio.Play();
				StartCoroutine("DisplayPainting",1.5f);

				break;
		
			}
			else
				print ("It isnt its child!");
		}

	}

	//if all puzzle pieces are fixed, then display the painting. In this level, the game is finished
	IEnumerator DisplayPainting(int time) 
	{
		yield return new WaitForSeconds(time);
		if (totalPiecesLeft == 0) { 
			soundDirector.play(SoundDirector.Mode.success);

			if (this.gameObject.GetComponent<SpriteRenderer> ())
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			else 
				GetComponentInChildren<SpriteRenderer>().enabled = true;
			director.FinishedLevel();
				}


	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.tag == "Player")
		{

			if(!hasSeenPressE && !string.IsNullOrEmpty(hint))
				flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.activateMessage,pressE);
			if(Input.GetButtonDown ("Interact") && !string.IsNullOrEmpty(hint))
			   {
				if(!hasInsertedFirstPuzzle)
					hintbox.UseMessageBox(gameObject,HintBoxController.Mode.activateMessage,hint);

				flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.deactivateFlashText,pressE);
				hasSeenPressE=true;

			   }
			
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Player" && !hasSeenPressE)
			flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.deactivateFlashText,pressE);

		if(col.tag == "Player" && hasSeenPressE)
			flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.permanentlyDeactivateFlash,pressE);
		if(col.tag == "Player" && !hasInsertedFirstPuzzle)
			hintbox.UseMessageBox(gameObject,HintBoxController.Mode.deactivateTextBox,hint);
		if(col.tag == "Player" && hasInsertedFirstPuzzle)
			hintbox.UseMessageBox(gameObject,HintBoxController.Mode.permanentlyDeactivateBox,hint);

	}


}
