using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HintBoxModel : MonoBehaviour {
	//need a list of gameobjects and their current hint box state: activated, deactivated their respective hints permanently

	//public List<GameObject> objs;
	private List<HintBoxState> stateOfHintBoxes;
	void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("puzzlePiece");
		GameObject plyr = GameObject.FindGameObjectWithTag ("Player");
		GameObject[] hintObj = GameObject.FindGameObjectsWithTag ("HasHint");
		GameObject[] elevatorObj = GameObject.FindGameObjectsWithTag ("Elevator");




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
	public void Add(GameObject obj)
	{
		stateOfHintBoxes.Add (new HintBoxState (obj));
		}
	public void Manipulate(GameObject obj, HintBoxController.Mode e  ,string hintText)
	{
		int validation = obj.GetInstanceID();
		HintBoxState currentState = stateOfHintBoxes.Find(x => x.obj.GetInstanceID() == validation);

		//if(!string.IsNullOrEmpty(hintText) && currentState.isActive)
		if (currentState == null)
						Debug.Log ("Is null");
		if(currentState.isActive )
		{

			if(e == HintBoxController.Mode.deactivateTextBox) //deactivate the current object's hint box interaction. Can be interacted with later. 
			{
				GetComponent<HintText>().DeactivateHintText();
			}
			if(e == HintBoxController.Mode.activateMessage)
			{
				GetComponent<HintText>().ActivateHintText(hintText);
			}



			if(e == HintBoxController.Mode.permanentlyDeactivateBox) //permanently deactivate the box. Can no longer be interacted with.
			{
				GetComponent<HintText>().DeactivateHintText();
				currentState.isActive =false;
			}
		}
	}




}

