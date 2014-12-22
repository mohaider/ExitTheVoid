using UnityEngine;
using System.Collections;

//TODO 	the piece touching where it fits must snap into its given place
//		to throw it, we set the kinematic to false, and its trigger to false. if it hits the ground
//		then set kinematic to true and trigger to true

public class GrabAndThrowPieces : MonoBehaviour {

	private bool isHoldingPiece = false; 
	private bool isThrowingPiece = false;
	public float throwingForce = 1000f;
	private PlayerControl playerControl;
	public float offsetX = 1f;
 

	private GameObject puzzlePiece;


	void Start()
	{

		playerControl = GetComponent<PlayerControl>();
	}
	void Update()
	{
	
		if (isHoldingPiece)
		{	if(isHoldingPiece && !isThrowingPiece)
			{
				print ("holding object");
				HoldObject ();

			}

		}
	}

	void FixedUpdate()
	{
		if (isHoldingPiece)
				if (Input.GetButtonDown ("Fire1"))
		{

				//ThrowObject ();
						StartCoroutine( PlaceObjectGently ());
		
		}
	}

	void HoldObject()
	{
		float objectOffsetPos = offsetX * playerControl.getDirection ().x; 
		Vector2 positionVector = new Vector2 (transform.position.x + objectOffsetPos, transform.position.y);

		//puzzlePiece.transform.position = new Vector2 (transform.position.x ,;
		puzzlePiece.transform.position = positionVector;
	}

	void GrabObject(GameObject piece)
	{
		if (Input.GetButtonDown ("Fire1"))
		{
			puzzlePiece = piece;
			puzzlePiece.renderer.sortingOrder = 1;
			isHoldingPiece = true;
		}
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "puzzlePiece" &&
		    gameObject.renderer.sortingLayerName == col.gameObject.renderer.sortingLayerName
		     && !isHoldingPiece)
			{
				print ("Player Touching " + col.gameObject.name);
				GrabObject (col.gameObject);
			}

		if (isHoldingPiece && col.gameObject.tag == "puzzlepieceFit")
		{

			FitPuzzlePiece fitter = col.gameObject.GetComponent<FitPuzzlePiece>();
			print ("player holding piece and touching the fitter!");
			if (fitter.WillItFit(puzzlePiece))
			{
				print ("puzzle will fit!");
				if (Input.GetButtonDown ("Fire1"))
				{
				
				//ThrowObject ();
					fitter.SetGrabbingPiece();
					StartCoroutine( PlaceObjectGently ());


				}
			}
		}
	}
	
	void ThrowObject()
	{


		isThrowingPiece = true;
		puzzlePiece.rigidbody2D.isKinematic = false;
		puzzlePiece.rigidbody2D.AddForce (new Vector2 (playerControl.getDirection().x *throwingForce, 1000f));
		//isHoldingPiece = false;

	}
	public void SwitchPieceSortingLayer()
	{
		if (puzzlePiece != null)
		{
			puzzlePiece.renderer.sortingLayerName = gameObject.renderer.sortingLayerName;
		}
		else return;
	}

	IEnumerator PlaceObjectGently()
	{

		isThrowingPiece = true;
		//puzzlePiece.rigidbody2D.isKinematic = false;
		puzzlePiece.rigidbody2D.AddForce (new Vector2 (playerControl.getDirection().x *throwingForce, 1000f));
		yield return new WaitForSeconds (0.5f);
		isHoldingPiece = false;
		isThrowingPiece = false;

	}
	public bool IsHoldingPiece()
	{
		return isHoldingPiece;
	}
}
