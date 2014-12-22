using UnityEngine;
using System.Collections;

//view class for flashing text

public class FlashingText : MonoBehaviour {


	

	public GUIText flashingGUIText;

	public string flashText;

	private bool flash = true;

	[Range(0.0f, 3f)]
	
	public float flashSpeed;

	private bool activatedFlash = false;
	
	// Update is called once per frame
	void Update () {

		if (activatedFlash) {
						
			if (flash) {
				Color col = flashingGUIText.color;								
				col.a = Mathf.Lerp (col.a, -0.25f, Time.deltaTime * flashSpeed);
				flashingGUIText.color = col;
				if (col.a < 0.15f)
					flash = false;
			} 

			else 
			{	
				Color col = flashingGUIText.color;
				col.a = Mathf.Lerp (col.a, 1.25f, Time.deltaTime * flashSpeed);
				flashingGUIText.color = col;
				if (col.a > 0.95f)
					flash = true;
			}
		}
	}


	public void DeactivateFlashText()
	{
		this.flashText = "";
		flashingGUIText.text = this.flashText;
		activatedFlash = false;
		flashingGUIText.enabled = false;
	}

	public void ActivateFlashText(string flashingText)
	{
		this.flashText = flashingText;
		flashingGUIText.text = this.flashText;
		activatedFlash = true;
		flashingGUIText.enabled = true;
	}
}
