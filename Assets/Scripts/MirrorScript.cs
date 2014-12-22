using UnityEngine;
using System.Collections;

public class MirrorScript : MonoBehaviour {



	private bool hasAlreadyInteracted =false;
	public GameObject puzzlepiece;
	public GameObject hintBox;
	private bool showHintBox = false;
	private HintBoxController hintbox;
	private FlashingTextController flashText;
	private string hint ="It seems that there is a puzzle \npiece stuck inside the mirror.\nMaybe if Nilan shrinks, his\nsmaller self could pick it up.";
	private string flashingTextMessage = "Press e";

	void Awake()
	{
		GameObject temp = GameObject.FindGameObjectWithTag ("HintBox");
		if( ErrorWindow<MirrorScript>.CanBeAssigned (temp,this, "HintBox")) 
			hintbox=temp.GetComponent<HintBoxController> ();

		GameObject tempFlash = GameObject.FindGameObjectWithTag ("FlashingTextBox");
		if( ErrorWindow<MirrorScript>.CanBeAssigned (tempFlash,this, "FlashingTextBox")) 
			flashText=tempFlash.GetComponent<FlashingTextController> ();

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player" && !hasAlreadyInteracted)
		{
			flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.activateMessage,flashingTextMessage);


			
		}


	}
	void OnTriggerStay2D(Collider2D col)
	{
		
		if( col.tag =="Player")
		{
			if (col.transform.localScale.y <=0.5f)
			{
				puzzlepiece.GetComponent<BoxCollider2D>().enabled=true;
			}
			if (col.transform.localScale.y >=0.5f)
			{
				puzzlepiece.GetComponent<BoxCollider2D>().enabled=false;
				//hintBox.GetComponent<HintText>().hintText = hint;
				//hintBox.SetActive(true);
            }
			if(Input.GetButtonDown("Interact"))
			{
				if (col.transform.localScale.y >=0.5f)
				{
					puzzlepiece.GetComponent<BoxCollider2D>().enabled=false;
//					hintBox.GetComponent<HintText>().UpdateText( hint);
//					hintBox.SetActive(true);
				}

				flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.permanentlyDeactivateFlash,"");
				hasAlreadyInteracted=true;
				GetComponent<ZoomIntoScene>().enabled = true;
				hintbox.UseMessageBox(puzzlepiece,HintBoxController.Mode.activateMessage,hint);
			}

        }

	}
	void OnTriggerExit2D(Collider2D col)
	{

		flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.deactivateFlashText,"");
		GetComponent<ZoomIntoScene> ().ResetZoom ();
		GetComponent<ZoomIntoScene>().enabled = false;
		hintbox.UseMessageBox(puzzlepiece,HintBoxController.Mode.deactivateTextBox,hint);
//		if (hintBox.activeSelf)				//if hint box is active, deactivate it
//			hintBox.SetActive(false);


		puzzlepiece.GetComponent<BoxCollider2D>().enabled=true;
	}
}
