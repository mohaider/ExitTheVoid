using UnityEngine;
using System.Collections;

public class FitPuzzlePiece : MonoBehaviour {

	
	public GameObject puzzlePiece;
	private GrabAndThrowPieces playerHold;
	private bool fitted =false;
	private bool grabbingPiece = false;
	private bool FinishedGrabbingPiece = false;
	public float smoothing  = 1.2f;
	public GameObject fitPieceParticleSystem;
	private bool particleTriggeredOnce = false;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null)
						playerHold = player.GetComponent<GrabAndThrowPieces> ();
				else if (player == null)
						Debug.Log ("Cannot find grab and throw pieces component from player");


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F2)) 
		{print (puzzlePiece.gameObject.name);
			print ("Player is holding piece "+ playerHold.IsHoldingPiece());
				}
			
	}
	void FixedUpdate()
	{
		if (grabbingPiece &&!FinishedGrabbingPiece)
			FitPiece ();
	}

	public void FitPiece()
	{
		float distanceBetween = Vector2.Distance (puzzlePiece.transform.position, transform.position);

		puzzlePiece.transform.position = Vector2.Lerp (puzzlePiece.transform.position, transform.position, Time.deltaTime*smoothing);
//		bool triggerParticle = (puzzlePiece.transform.position.x - transform.position.x <=0  ) && (puzzlePiece.transform.position.y - transform.position.y <=0) ;
//		GameObject particleTrigger;
//		if (triggerParticle)
//			 particleTrigger = Instantiate(fitPieceParticleSystem, transform.position,Quaternion.identity) as GameObject;
		if (distanceBetween <= 0.01f) 
		{
			GameObject directorObj = GameObject.FindGameObjectWithTag ("Director");
			print ("fitting piece");
			Director director = directorObj.GetComponent<Director> ();
						//tell the director to instantiate doorway
			director.OnePuzzleSolved ();
			FinishedGrabbingPiece = true;
			GameObject particleTrigger = Instantiate(fitPieceParticleSystem, transform.position,Quaternion.identity) as GameObject;
		}


	}
	public void SetGrabbingPiece()
	{
		grabbingPiece = true;
	}



	public bool WillItFit(GameObject obj)
	{
		return (puzzlePiece.GetInstanceID() == obj.GetInstanceID());
	}
}
