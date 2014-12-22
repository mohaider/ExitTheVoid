using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class HintBoxController : MonoBehaviour {

	public string HintText;
	public enum Mode { activateMessage, permanentlyDeactivateBox,deactivateTextBox };




	public void AddObj(GameObject obj)
	{
		GetComponent<HintBoxModel> ().Add (obj);
	}
	public void UseMessageBox(GameObject obj, Mode e,string hintText)
	{
		GetComponent<HintBoxModel>().Manipulate( obj,  e, hintText);
	}

	public void UseFlashingTextBox(GameObject obj, Mode e, string flashingText)
	{}



}
