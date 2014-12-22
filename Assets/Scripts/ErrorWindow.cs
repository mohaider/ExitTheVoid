using UnityEngine;
using System.Collections;

public class ErrorWindow<T>: MonoBehaviour  {

	public static bool  CanBeAssigned(GameObject state, T classVar, string objectWithTag)
	{

		if (state == null)
		{
			print( classVar.ToString() + " failed to find gameobject with tag   " + objectWithTag);
			return false;
		}
		else return true;

	}


}
