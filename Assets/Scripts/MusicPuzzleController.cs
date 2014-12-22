using UnityEngine;
using System.Collections;


public class MusicPuzzleController : MonoBehaviour {
	private char[] correctSequence = {'A','D','F'} ;
	private int currentIndex = 0 ;
	private string sequence;
	public bool isSolved = false;
	



	public GameObject[] musicTeleporters;

	public AudioClip wrongBuzzer;
	public AudioClip correctSound;

	public GameObject puzzlePiece;
	public Transform puzzlePieceLerpingPos;
	public float lerpSpeed = 0.5f;

	void Update()
	{
		if (isSolved)
			BringPuzzleDown ();
	}

	 void Awake()
	{
		if (musicTeleporters.Length == 0)
						Debug.Log ("No music teleporting pieces added!");


	}

	void AddToSequence( char note)
	{

		if (correctSequence [currentIndex] != note)
						Incorrect ();
		else 
		{
			currentIndex++;
		if (currentIndex >= correctSequence.Length)
			Solved ();
		}

	}

	void BringPuzzleDown()
	{
		puzzlePiece.transform.position = Vector2.Lerp (puzzlePiece.transform.position, 
		                                               puzzlePieceLerpingPos.position, Time.deltaTime * lerpSpeed);
		puzzlePiece.GetComponent<SpriteRenderer>().enabled = true;
		if (Vector2.Distance(puzzlePiece.transform.position,puzzlePieceLerpingPos.position) < 0.5f)
		{
			puzzlePiece.transform.position = puzzlePieceLerpingPos.position;


			isSolved = false;
		}

		}

	void Solved()
	{

		//play compiled note
		//disable colliders of portals
		for (int i = 0 ; i < musicTeleporters.Length ; i ++)
		{
			musicTeleporters[i].GetComponent<CircleCollider2D>().enabled = false;

		}
		StartCoroutine ("waitTwoSecondsAndPlay");
	}

	IEnumerator waitTwoSecondsAndPlay()
	{
		yield return new WaitForSeconds (1.5f);
		System.Object[] arguments = {correctSound, 1f};
		gameObject.GetComponent<playNote> ().SendMessage ("PlayThis", arguments);
	//	puzzlePiece.SetActive (true);
		puzzlePiece.GetComponent<BoxCollider2D>().enabled = true;
		isSolved = true;
		}

	void Incorrect()
	{
		//reset index to 0
		currentIndex = 0;
		System.Object[] arguments = {wrongBuzzer, 0.1f};
		gameObject.GetComponent<playNote> ().SendMessage ("PlayThis", arguments);
		//play buzzer
	

	}


}
