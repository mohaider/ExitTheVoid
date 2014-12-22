using UnityEngine;
using System.Collections;

public class DisplayHint : MonoBehaviour {

	private bool hintDisplayed = false;
	private bool flashingTextDisplayed = false;

	private int timeRemainingToDisplayhint = 2;
	private int timeRemaningToDisplayFlash = 2;

	public string hint = "";
	public string flashingText = "";


	private HintBoxController hintbox;
	private FlashingTextController flashText;

	void Awake()
	{
		GameObject temp = GameObject.FindGameObjectWithTag ("HintBox");
		if (ErrorWindow<DisplayHint>.CanBeAssigned (temp, this, "HintBox")) {
			hintbox = temp.GetComponent<HintBoxController> ();
		//	hintbox.AddObj(gameObject);
		}
		
		GameObject tempFlash = GameObject.FindGameObjectWithTag ("FlashingTextBox");
		if( ErrorWindow<DisplayHint>.CanBeAssigned (tempFlash,this, "FlashingTextBox")) 
		{
			flashText=tempFlash.GetComponent<FlashingTextController> ();
		//	flashText.AddObj(gameObject);
		}

		}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player") {
			print ("Nilan is touching this");
			if(Input.GetButtonDown("Interact"))
				if(timeRemainingToDisplayhint >0 && !string.IsNullOrEmpty(hint))
				{
				print ("Nilan is trying to interact with this");
					hintbox.UseMessageBox(gameObject,HintBoxController.Mode.activateMessage,hint);
				timeRemainingToDisplayhint--;
					hintDisplayed =true;

				}

			if(timeRemaningToDisplayFlash>0 && !string.IsNullOrEmpty(flashingText))
			{
				print ("Trying to flash text");
				flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.activateMessage,flashingText);
				flashingTextDisplayed = true;
				if(Input.GetKeyDown(KeyCode.F)) 
				   flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.permanentlyDeactivateFlash,flashingText);

			}
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player") {
			
			print ("Nilan left");
				if(timeRemainingToDisplayhint ==0)
			{
				hintbox.UseMessageBox(gameObject,HintBoxController.Mode.permanentlyDeactivateBox,hint);
				
			}
			
			if(timeRemaningToDisplayFlash ==0)
			{
				flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.permanentlyDeactivateFlash,flashingText);
				
			}
			else{
				hintbox.UseMessageBox(gameObject,HintBoxController.Mode.deactivateTextBox,hint);
				flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.deactivateFlashText,flashingText);
				timeRemaningToDisplayFlash --;


			}
		}

	}
}
