using UnityEngine;
using System.Collections;

public class PowerUpGameObjects : MonoBehaviour {

	public GameObject[] poweredUpObjects;
	private bool hasActivated = false;
	private HintBoxController hintbox;
	private string messageText = "You start to hear a soft rumble \neminating from the steam generator";
	private FlashingTextController flashText;
	private string flashMessage = "Press e";
	private SoundDirector soundDirector;
	bool flashNow=true;

	void Awake()
	{
		GameObject temp = GameObject.FindGameObjectWithTag ("HintBox");
		
		if( ErrorWindow<PowerUpGameObjects>.CanBeAssigned (temp,this, "HintBox")) 
			hintbox=temp.GetComponent<HintBoxController> ();

		GameObject tempflash = GameObject.FindGameObjectWithTag ("FlashingTextBox");
		
		if( ErrorWindow<PowerUpGameObjects>.CanBeAssigned (tempflash,this, "FlashingTextBox")) 
			flashText=tempflash.GetComponent<FlashingTextController> ();

		GameObject soundDirObj = GameObject.FindGameObjectWithTag ("SoundDirector");
		if (soundDirObj != null)
			soundDirector = soundDirObj.GetComponent<SoundDirector> ();
		else
			Debug.Log ("Cannot find the SoundDirector!");
			
	}

	void OnTriggerStay2D(Collider2D col)
	{

		if (col.tag == "Player" )
		{
			if (flashNow)
			{
				flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.activateMessage,flashMessage);
			}
			if( Input.GetButtonDown("Interact"))
			{
			
				soundDirector.play (SoundDirector.Mode.eventSuccess);
				for (int i = 0 ; i < poweredUpObjects.Length ; i ++)
					poweredUpObjects[i].SendMessage("TurnPowerOn");

				

				hintbox.UseMessageBox(gameObject,HintBoxController.Mode.activateMessage,messageText);
				hasActivated =true;
				flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.permanentlyDeactivateFlash,"");

				flashNow=false;
			}
		}


	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag =="Player")
		{
			if(hasActivated )
			{
		
				gameObject.GetComponent<BoxCollider2D>().enabled = false;
				hintbox.UseMessageBox(gameObject,HintBoxController.Mode.deactivateTextBox,messageText);
			}
			if(flashNow)
				flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.deactivateFlashText,"");

		}
	}
}
