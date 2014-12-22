using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FlashingTextModel : MonoBehaviour {

	//need a list of gameobjects and their current hint box state: activated, deactivated their respective hints permanently
	
	//public List<GameObject> objs;
	private List<HintBoxState> stateOfHintBoxes;
	void Awake()
	{

		print ("flash text awake");
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("puzzlePiece");
		GameObject plyr = GameObject.FindGameObjectWithTag ("Player");
		GameObject[] hintObj = GameObject.FindGameObjectsWithTag ("HasHint");
		GameObject[] elevatorObj = GameObject.FindGameObjectsWithTag ("Elevator");
		
		
		if (objs == null)
						print ("objs is null");
		
		stateOfHintBoxes = new List<HintBoxState> ();
		for (int i = 0; i < objs.Length; i++)
		{
			stateOfHintBoxes.Add(new HintBoxState(objs[i]));
		}
		for (int i = 0 ; i< hintObj.Length; i++)
		{
			stateOfHintBoxes.Add(new HintBoxState(hintObj[i]));
		}
		for (int i = 0 ; i< elevatorObj.Length; i++)
		{
			stateOfHintBoxes.Add(new HintBoxState(elevatorObj[i]));
			
		}
		
		stateOfHintBoxes.Add (new HintBoxState (plyr));
		
	}
	public void AddObj(GameObject obj)
	{

		stateOfHintBoxes.Add (new HintBoxState (obj));
	
		}
	public void Manipulate(GameObject obj, FlashingTextController.Mode e  ,string flashText)
	{
		int validation = obj.GetInstanceID();
		HintBoxState currentState = stateOfHintBoxes.Find(x => x.obj.GetInstanceID() == validation);
		
		//if(!string.IsNullOrEmpty(hintText) && currentState.isActive)
		
		if(currentState.isActive)
		{
			
			if(e == FlashingTextController.Mode.deactivateFlashText) //deactivate the current object's hint box interaction. Can be interacted with later. 
			{
				GetComponent<FlashingText>().DeactivateFlashText();
			}
			if(e == FlashingTextController.Mode.activateMessage)
			{
				GetComponent<FlashingText>().ActivateFlashText(flashText);
			}
			
			
			
			if(e == FlashingTextController.Mode.permanentlyDeactivateFlash) //permanently deactivate the box. Can no longer be interacted with.
			{
				GetComponent<FlashingText>().DeactivateFlashText();
				currentState.isActive =false;
			}
		}
	}
	
	
	

}
