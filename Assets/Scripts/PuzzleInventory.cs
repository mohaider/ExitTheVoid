using UnityEngine;
using System.Collections;


public class PuzzleInventory : MonoBehaviour{
	private bool isCarryingPuzzlePiece = false;
	public Texture puzzleIcon;
	public Texture emptyIcon;
	public GameObject itemPickupParticles;

	public GUITexture InventoryDisplay;
	private GameObject puzzlePiece;
	public string pressF = "Press f to place piece"; 
	private bool pressedF = false;
	private bool insertedFirstPuzzle = false;
	private FlashingTextController flashText;

	void Awake()
	{
		GameObject tempFlash = GameObject.FindGameObjectWithTag ("FlashingTextBox");
		if( ErrorWindow<PuzzleInventory>.CanBeAssigned (tempFlash,this, "FlashingTextBox")) 
		{
		
			flashText=tempFlash.GetComponent<FlashingTextController> ();

			flashText.AddObj(gameObject);
		}

	}




	void OnGui()
	{
		GUILayout.Label (puzzleIcon);
	}

	void OnTriggerStay2D(Collider2D col)
	{

		if (col.tag == "puzzlePiece" && !isCarryingPuzzlePiece)
		{

			if (Input.GetButtonDown ("PickUpPiece"))
			{
				puzzlePiece = col.gameObject;
				SpriteRenderer icon = col.gameObject.GetComponent<SpriteRenderer>();
				//puzzleIcon = icon.sprite.texture;
				InventoryDisplay.guiTexture.texture = puzzleIcon;
				//InventoryDisplay.pixelInset= new Rect(-70,-47, puzzleIcon.width/2,puzzleIcon.height/2);
				isCarryingPuzzlePiece = true;
				col.gameObject.SendMessage("OnPickup");
				col.gameObject.SetActive(false);

				Vector2 particlePos = transform.position;
				particlePos.x -= 0.1f;
				GameObject part = (GameObject) Instantiate(itemPickupParticles, transform.position+Vector3.up*3.0f,Quaternion.identity);
				part.transform.parent= transform;
			}
		}

		if (col.tag == "puzzlepieceFit" && isCarryingPuzzlePiece)
		{
			if (puzzlePiece != null)
			{
				bool canFit = puzzlePiece.GetComponent<PuzzlePieceParentCheck>().isParent(col.gameObject);
				print (canFit);
				if(!insertedFirstPuzzle)
				{
					print ("Trying to give a flashing text message to inserting the key");
					flashText.UseFlashMsg(gameObject, FlashingTextController.Mode.activateMessage,pressF);

				}
				if (canFit && Input.GetButtonDown ("PickUpPiece"))
				{
					print ("Inserting the puzzle piece");
					flashText.UseFlashMsg(gameObject, FlashingTextController.Mode.permanentlyDeactivateFlash,pressF);
					insertedFirstPuzzle = false;
					col.gameObject.SendMessage("ActivatePiece", puzzlePiece);
					puzzlePiece = null;
					isCarryingPuzzlePiece=false;
					//puzzleIcon =emptyIcon;

					InventoryDisplay.guiTexture.texture = emptyIcon;
				}


				 }
		}

	}
}
