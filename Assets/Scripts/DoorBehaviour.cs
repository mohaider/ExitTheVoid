using UnityEngine;
using System.Collections;


//TODO 
/// <summary>
/// 
/// 
/// 
/// 
/// Behaviour of the door. Interaction with key
/// </summary>
public class DoorBehaviour : MonoBehaviour {

	public bool YellowDoor  = false; //change the bool to change the behavior of the door to rotate instead of change sprites.
	public SpriteRenderer unlockedDoor;
	private GameObject player;
	private bool isClosed = true;
	private bool hasAlreadyInteracted = false;
	private string hint = "Seems like the door is locked.";
	private string flashingTextMsg = "Press e";
	private HintBoxController hintBox;
	private FlashingTextController flashText;
	SoundDirector soundDirector;

	void Awake()
	{
		hintBox = GameObject.FindGameObjectWithTag ("HintBox").GetComponent<HintBoxController> ();
		flashText = GameObject.FindGameObjectWithTag ("FlashingTextBox").GetComponent<FlashingTextController> ();
		soundDirector = GameObject.FindGameObjectWithTag ("SoundDirector").GetComponent<SoundDirector> ();
	}

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OpenDoor()
	{
		if(YellowDoor)
		{
			transform.Rotate (0f, 180f, 0f);
			transform.position += Vector3.right * 6.65f;
		}
		else
		{
			unlockedDoor.enabled = true;

		}
		isClosed = false;
		hasAlreadyInteracted = true;
		soundDirector.play (SoundDirector.Mode.unlock);
		gameObject.collider2D.enabled = false;
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		print ("disabled collider");
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if ((col.gameObject.tag == "Player") && (!hasAlreadyInteracted))
		{
			flashText.UseFlashMsg(player, FlashingTextController.Mode.activateMessage, flashingTextMsg);
		}
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (Input.GetButtonDown("Interact"))
		{
			if ((player.GetComponent<Holder>().hasKey) && (isClosed))
			{
				OpenDoor();
				player.GetComponent<Holder>().hasKey = false;
				flashText.UseFlashMsg(player,FlashingTextController.Mode.permanentlyDeactivateFlash,"");
			}
			else
			{
				// Use hint
				flashText.UseFlashMsg(player,FlashingTextController.Mode.permanentlyDeactivateFlash,"");
				hasAlreadyInteracted = true;
				hintBox.UseMessageBox(player, HintBoxController.Mode.activateMessage, hint);
			}
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		flashText.UseFlashMsg(player,FlashingTextController.Mode.deactivateFlashText,"");
		hintBox.UseMessageBox(player,HintBoxController.Mode.deactivateTextBox,hint);
	}
}
