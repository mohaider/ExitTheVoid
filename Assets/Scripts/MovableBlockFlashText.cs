using UnityEngine;
using System.Collections;

/// <summary>
/// flash text hint for the movable block
/// </summary>

public class MovableBlockFlashText : MonoBehaviour {

	private FlashingTextController flashText;
	private string flashingTextMsg = "???";

	void Awake () {
		flashText = GameObject.FindGameObjectWithTag ("FlashingTextBox").GetComponent<FlashingTextController> ();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			flashText.UseFlashMsg(col.gameObject, FlashingTextController.Mode.activateMessage, flashingTextMsg);
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			flashText.UseFlashMsg(col.gameObject,FlashingTextController.Mode.activateMessage,flashingTextMsg);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		flashText.UseFlashMsg(col.gameObject,FlashingTextController.Mode.deactivateFlashText,"");
	}
}
