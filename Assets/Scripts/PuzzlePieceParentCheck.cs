using UnityEngine;
using System.Collections;

public class PuzzlePieceParentCheck : MonoBehaviour {
	public GameObject parent;


	//The following script checks if the passed parameter is indeed the parent. 
	public bool isParent(GameObject fit)
	{
		return (parent.GetInstanceID () == fit.GetInstanceID ());

	}
}
