using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	public GameObject inventoryPos;
	private bool isCarryingPuzzlePiece = false;
	void Start()
	{
		//inventoryPos = new GameObject ();
//		inventoryPos.guiTexture.texture = null;
	}

	void InsertPiece(GameObject piece)
	{
		if (piece.GetComponent<GUITexture>().texture)
		{
			inventoryPos.guiTexture.texture = piece.guiTexture.texture;
		}
	}

	void DeletePiece()
	{
		inventoryPos.guiTexture.texture = null;
	}

	void OnTriggerStay2D(Collider2D col)
	{

	}

}
