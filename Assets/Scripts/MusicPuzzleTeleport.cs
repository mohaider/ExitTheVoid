using UnityEngine;
using System.Collections;

public class MusicPuzzleTeleport : MonoBehaviour {
	public GameObject otherDoor;

	public GameObject TeleportParticleEffect;
	public GameObject puzzleController;
	public AudioClip note;
	private char charNotes;
	
	void Awake()
	{
		charNotes = note.name [0];

	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{	
			TeleportToOtherDoor (col.gameObject);
		}
	}
	
	void TeleportToOtherDoor(GameObject plr)
	{
		
		if (Input.GetButtonDown("Interact"))
		{	
			
			plr.gameObject.transform.position = otherDoor.transform.position;
			System.Object[] arguments = {note,1f};
			puzzleController.SendMessage("PlayThis", arguments);
			GameObject obj = Instantiate(TeleportParticleEffect, otherDoor.transform.position,Quaternion.identity) as GameObject;

			puzzleController.SendMessage("AddToSequence",charNotes);
			
		}
		
	}
	

}
