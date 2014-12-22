using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
	

	public float switchingWorldScalar = -17f;
	public bool inTheVoid = true;
	public GameObject exitTunnel;
	public GameObject toppartoftunnel;
	private int numOfpuzzlePiece;
	private CameraFade cameraFader;
	GameObject player;
	public bool inDebugMode = true;
	public GameObject onDeathParticle;
	private bool nilanIsDead = false;
	public Transform respawnPos; 
	private ShrinkPlayer shrink;
	private Checkpoint checkpoint;
	private bool levelFinished =false;
	ShadingHandler playerShade;
	private MusicDirector musicDirector;

	void Awake()
	{
		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");
		cameraFader = cam.GetComponent<CameraFade> ();
		cameraFader.SetScreenOverlayColor (Color.black);
		cameraFader.StartFade (Color.clear, 3f);
		player = GameObject.FindGameObjectWithTag ("Player");

		GameObject musicDir = GameObject.FindGameObjectWithTag ("MusicDirector");
		if (musicDir != null)
						musicDirector = musicDir.GetComponent<MusicDirector> ();
			else
				Debug.Log ("Cannot find music director");

	}

	public bool isPlayerDead()
	{
		return nilanIsDead;
		}

	public void PlayerIsDead()
	{
		musicDirector.playMusic (MusicDirector.mode.voidMusicSound);
		nilanIsDead = true;
		onDeathParticle.transform.position = player.transform.position;
		player.SetActive (false);

		onDeathParticle.SetActive (true);
		Invoke ("Respawn", 3f);

		}
	void Respawn()
	{

		onDeathParticle.SetActive (false);
		player.SetActive (true);
		RestartInCheckpoint ();
		playerShade.setChangingColorTotrue ();//TODO COME BACK HERE AND FIGURE IT OUT
		nilanIsDead = false;
		}

	void RestartInCheckpoint()
	{
		//player = checkpoint.player;
		player.transform.position = checkpoint.position;
		//Destroy(player.GetComponent<PuzzleInventory> ());
		//player.AddComponent<PuzzleInventory> ();
		GameObject[] go = GameObject.FindGameObjectsWithTag ("puzzlePiece");
		for (int i = 0; i < go.Length; i++)
		{
			go[i] = checkpoint.puzzlePieces[i];
			i++;
		}
		GameObject p = GameObject.FindGameObjectWithTag ("puzzlepieceFit");
		p = checkpoint.puzzle;
		Camera.main.transform.position = (Vector3)checkpoint.position + (Vector3.back * 10f);
	}

	// Use this for initialization
	void Start () {
		shrink = player.GetComponent<ShrinkPlayer> ();
		FindPlayer ();

		SaveCheckpoint ();

		GameObject[] puzzlePieceFitters = GameObject.FindGameObjectsWithTag ("puzzlepieceFit");
		numOfpuzzlePiece = puzzlePieceFitters.Length;
	
	}

	public void SaveCheckpoint()
	{
		checkpoint = new Checkpoint (player.GetComponent<PuzzleInventory>(), player, 
		                             GameObject.FindGameObjectWithTag("puzzlepieceFit"), player.transform.position,
		                             GameObject.FindGameObjectsWithTag("puzzlePiece"));
	}

	// Update is called once per frame
	void Update () {
		switchWorlds ();
		if (!inDebugMode && numOfpuzzlePiece == 0) {
			numOfpuzzlePiece = -1;
						CreateExitTunnel ();
				}
	}

	// Restarts the level upon death of the player
	IEnumerator RestartLevel(int waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		Application.Quit ();
		Application.LoadLevel (0);
	}

	void FindPlayer()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null )
		{
			playerShade = player.GetComponent<ShadingHandler>();
		}
		else if (player == null)
		{
			Debug.Log("cannot find PlayerControls!");
		}

	}

	void switchWorlds()

	{
//		if (Input.GetKeyDown(KeyCode.F1))
//		    {
//						playerShade.SwitchWorlds(switchingWorldScalar);
//						Camera cam = Camera.main;
//			//			Camera.main.transform.position = new Vector3 (cam.transform.position.x, cam.transform.transform.position.y, cam.transform.transform.position.z + switchingWorldScalar);
//			Camera.main.transform.position = new Vector3 (cam.transform.position.x, cam.transform.transform.position.y+ switchingWorldScalar, cam.transform.transform.position.z );		
//			switchingWorldScalar *= -1;
//		}


		

	}

	//include parameters
	public void switchWorlds(GameObject otherlocation)
	{

		//playerShade.SwitchWorlds(otherlocation, switchingWorldScalar);
		Camera cam = Camera.main;
		Vector3 otherWorldPos = otherlocation.transform.position;
		otherWorldPos.z = -10;
		Camera.main.transform.position = otherWorldPos;
		//Camera.main.transform.position = new Vector3 (cam.transform.position.x, cam.transform.position.y + switchingWorldScalar, cam.transform.position.z );
		switchingWorldScalar *= -1;

		if (!shrink.isOnTheVoid)
			shrink.gameObject.transform.localScale = shrink.soulmeter.transform.localScale;
		else
			shrink.soulmeter.transform.localScale = shrink.gameObject.transform.localScale;
		
		shrink.isOnTheVoid = !shrink.isOnTheVoid;
		inTheVoid = shrink.isOnTheVoid;
		print("player after switching "+player.GetComponent<ShrinkPlayer>().isOnTheVoid);

		if (musicDirector != null) {
						if (!inTheVoid)
								musicDirector.playMusic (MusicDirector.mode.realityMusicSound);
						else
								musicDirector.playMusic (MusicDirector.mode.voidMusicSound);
				}
	}

	public void CreateExitTunnel()
	{
		var GameObject = Instantiate (exitTunnel, exitTunnel.transform.position, Quaternion.identity);
		 GameObject  two = Instantiate (toppartoftunnel, exitTunnel.transform.position, Quaternion.identity) as GameObject;
	}

	public void FinishedLevel()
	{

		levelFinished = true;
		exitTunnel.SetActive(true);
	}
	public void OnePuzzleSolved()
	{
		numOfpuzzlePiece--;
	}

	public void SetCameraBackGround (string playerLocationInWorld)
	{
//		cameraFader.StartFade (Color.clear, 3f);
//		print ("playerLocationInWorld "+playerLocationInWorld);
//		if (playerLocationInWorld == "voidPlayer")
//			Camera.main.backgroundColor = new Color (68f/255f, 38f/255f, 67f/255f, 1f);
//		else if (playerLocationInWorld == "realityPlayer")
//			Camera.main.backgroundColor = new Color (255f/255f, 205f/255f, 129f/255f, 1f);

	}
}
