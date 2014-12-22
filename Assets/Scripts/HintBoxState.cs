using UnityEngine;
using System.Collections;

public class HintBoxState  {

	public GameObject obj;
	public bool isActive;
	
	public HintBoxState(GameObject obj)
	{
		this.obj = obj;
		this.isActive = true;
	}
	HintBoxState(GameObject obj,bool state)
	{
		this.obj = obj;
		this.isActive = state;
	}
	
	void Deactivate(bool state)
    {
        this.isActive = false;
    }
    
}
