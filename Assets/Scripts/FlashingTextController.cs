using UnityEngine;
using System.Collections;

public class FlashingTextController : MonoBehaviour {


	
	public string FlashingText;
	public enum Mode { activateMessage, permanentlyDeactivateFlash,deactivateFlashText };
	
	
	
	public void AddObj(GameObject obj)
	{
		GetComponent<FlashingTextModel>().AddObj(obj);
		}
	
	public void UseFlashMsg(GameObject obj, Mode e,string hintText)
	{
		GetComponent<FlashingTextModel>().Manipulate( obj,  e, hintText);
	}
	

}
