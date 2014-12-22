using UnityEngine;
using System.Collections;

public class ActivateElevator : MonoBehaviour {

	public BoxCollider2D[] boxesToDisable;
	public bool onTopFloor = true;
	private bool isActivated = false;
	private bool isMoving = false;
	private bool moveDown = false;
	private bool moveUp = true;
	public bool actPuzAtTop = false;		//activate the puzzle piece when Elevator is at the top position
	private bool piecePickedUp = false;		//is the piece picked up or no?

	private GameObject player;
	public float elevationRate = 5.0f;
	public GameObject spark;
	public GameObject otherElevator;
	public AudioClip bell;
	Vector2 floor01,floor02;

	public bool isPowered = false;
	public GameObject positionThePlayer;
	string message = "Calling on the elevator" +
					 "\ndoesn't seem to do anything.";


	private SoundDirector soundDirector;
	private HintBoxController hintbox;

	private bool NilanIsOnThisElevator = false;

	void Awake()
	{
		
		GameObject temp = GameObject.FindGameObjectWithTag ("HintBox");
		
		if( ErrorWindow<ActivateElevator>.CanBeAssigned (temp,this, "HintBox")) 
			hintbox=temp.GetComponent<HintBoxController> ();


		GameObject soundDirObj = GameObject.FindGameObjectWithTag ("SoundDirector");
		if (soundDirObj != null)
			soundDirector = soundDirObj.GetComponent<SoundDirector> ();
		else
			Debug.Log ("Cannot find the SoundDirector!");
	}
	// Use this for initialization
	void Start () {
		floor01 = new Vector2 (transform.position.x, 385f);
		floor02 = new Vector2 (transform.position.x, 412f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isActivated)
		{
			ElevatorControl ();
		}


	}

	void PlaySound()
	{
		//audio.clip = bell;
		//audio.Play ();
		soundDirector.play (SoundDirector.Mode.elevatorArrival);
		
	}

	void GiveDownForce()
	{
		if(NilanIsOnThisElevator)
			player.transform.position = positionThePlayer.transform.position;
		//player.rigidbody2D.AddForce (-Vector2.up *500f);
		
		}



	void ElevatorControl()
	{
		if (onTopFloor && isMoving )
		{	
			transform.position = Vector2.Lerp (transform.position, floor01, Time.deltaTime * elevationRate);
			GiveDownForce();
		}
		if (onTopFloor && isMoving && transform.position.y <= 385f + 0.2f)
		{

		//	PlaySound();
			onTopFloor = false;
			isMoving = false;

			transform.position = floor01;
			isActivated = false;
			ReactivateControls();
			spark.SetActive(false);

//			if (!actPuzAtTop)
//				ActivatePuzzlePiece();
//			if (actPuzAtTop)
//				DeactivatePuzzlePiece();


		}


		if (!onTopFloor && isMoving) {

				transform.position = Vector2.Lerp (transform.position, floor02, Time.deltaTime * elevationRate);
				GiveDownForce();
				}

		if (!onTopFloor && isMoving && transform.position.y >= 412f - 0.2f)
		{

			//PlaySound();
			onTopFloor = true;
			isMoving = false;

			transform.position = floor02;
			isActivated = false;
			ReactivateControls();
			spark.SetActive(false);

//			if (actPuzAtTop)
//				ActivatePuzzlePiece();
//			if (!actPuzAtTop)
//				DeactivatePuzzlePiece();
		}
	}

	void reActivateOtherElevatorControl()
	{
		ControlOtherElevators controller = gameObject.transform.GetChild(0).GetComponent<ControlOtherElevators> ();
		if (controller == null)
				return;
		else
				controller.enabled = true;

	}


	void ReactivateControls()
	{
		for (int i = 0 ; i <boxesToDisable.Length ; i++)
		{
			boxesToDisable[i].enabled =true;
		}
		player.SendMessage ("ReactivateControls");
	}


//	void Activate()
//	{
//		print("activating elevator controls without player option");
//		for (int i = 0 ; i <boxesToDisable.Length ; i++)
//		{
//			boxesToDisable[i].enabled =false;
//		}
//	}

	void Activate(GameObject player)
	{
		if (isPowered) {
						
						for (int i = 0; i <boxesToDisable.Length; i++) {
								boxesToDisable [i].enabled = false;
						}
						if (otherElevator != null)
								otherElevator.SendMessage ("Activate", player);
						this.player = player;
						player.SendMessage ("DeactivateControls");
						isActivated = true;
						spark.SetActive (true);
						isMoving = true;
						if (!piecePickedUp)
								StartCoroutine ("ActOrInactPuzzle");
			soundDirector.play (SoundDirector.Mode.elevatorArrival);

				}
		if (!isPowered)
						DisplayMessage ();

	}
	void DisplayMessage()
	{
		hintbox.UseMessageBox (gameObject, HintBoxController.Mode.activateMessage, message);

		}
	IEnumerator ActOrInactPuzzle()
	{
		yield return new WaitForSeconds (0.0f); //wait a few seconds

		if (actPuzAtTop && !onTopFloor)
						ActivatePuzzlePiece ();
		if (!actPuzAtTop && onTopFloor)
						ActivatePuzzlePiece ();
				else
						DeactivatePuzzlePiece ();


		}
	void ActivatePuzzlePiece()
	{
		ActivateDeactivatePuzzle piece = GetComponent<ActivateDeactivatePuzzle> ();
		if (piece != null)
						piece.Activate ();

	}

	void DeactivatePuzzlePiece()
	{
		ActivateDeactivatePuzzle piece = GetComponent<ActivateDeactivatePuzzle> ();
		if (piece != null)
			piece.Deactivate ();


	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player") {

			NilanIsOnThisElevator = true;
	
				}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player") {

			NilanIsOnThisElevator = false;
			if(!isPowered)
			{
				hintbox.UseMessageBox (gameObject, HintBoxController.Mode.deactivateTextBox, message);
			}
		}
	
	}
	void PuzzlePiecePickedUp()
	{
		piecePickedUp = true;


	}
	void TurnPowerOn()
	{
		isPowered = true;
	}
	void TurnPowerOff()
	{
		isPowered = false;
	}
}
