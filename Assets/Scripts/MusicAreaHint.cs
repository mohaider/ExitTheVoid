using UnityEngine;
using System.Collections;

public class MusicAreaHint : MonoBehaviour {


		private bool hintDisplayed = false;
	private bool flashingTextDisplayed = false;
	
	private int timeRemainingToDisplayhint = 2;
	private int timeRemaningToDisplayFlash = 2;
	
	private string hint = "Can you solve the musical puzzle?\nHint: its the first three notes\nof Bethoven's moonlight Sonata";
	public string flashingText = "";
	
	
	private HintBoxController hintbox;

	
	void Awake()
	{
		GameObject temp = GameObject.FindGameObjectWithTag ("HintBox");
		if (ErrorWindow<MusicAreaHint>.CanBeAssigned (temp, this, "HintBox")) {
			hintbox = temp.GetComponent<HintBoxController> ();
			//	hintbox.AddObj(gameObject);
		}
		
	
		
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player") {
			print ("Nilan is touching this");

				if(!hintDisplayed && !string.IsNullOrEmpty(hint))
			{

				hintbox.UseMessageBox(gameObject,HintBoxController.Mode.activateMessage,hint);
				timeRemainingToDisplayhint--;
				hintDisplayed =true;
				
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
			

			else{
				hintbox.UseMessageBox(gameObject,HintBoxController.Mode.deactivateTextBox,hint);

				timeRemaningToDisplayFlash --;
				
				
			}
		}
		
	}
}
