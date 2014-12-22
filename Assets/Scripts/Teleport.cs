using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public GameObject otherDoor;

	private PlayerPositioning player; 
	private Director director;
	private ShrinkPlayer shrink;
	public GameObject TeleportParticleEffect;
	private GameObject soulmeter;
	private SoundDirector soundDirector;
	//is this teleport going to be used to teleport between void and reality?
	public bool switchToVoid = true;

	// Use this for initialization
	void Start () {

		GameObject directorObj = GameObject.FindGameObjectWithTag ("Director");
		GameObject soundDirObj = GameObject.FindGameObjectWithTag ("SoundDirector");
		if (directorObj != null)
						director = directorObj.GetComponent<Director> ();
				else if (directorObj == null)
						Debug.Log ("Cannot find the Director!");
		if (soundDirObj != null)
			soundDirector = soundDirObj.GetComponent<SoundDirector> ();
		else
		Debug.Log ("Cannot find the SoundDirector!");

		GameObject obj = GameObject.FindGameObjectWithTag ("Player");
		if (obj != null )
		{
			player = obj.GetComponent<PlayerPositioning>();
			shrink = obj.GetComponent<ShrinkPlayer>();
		}
		else if (obj == null)
		{
			Debug.Log("cannot find PlayerControls!");
		}

		soulmeter = GameObject.FindGameObjectWithTag ("Soulmeter");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{	

			TeleportToOtherDoor (col.gameObject);
		}
	}

	void TeleportToOtherDoor(GameObject plr)
	{

		if (Input.GetButtonDown("Interact"))
		{	
			if (switchToVoid && soundDirector !=null)
			{
				soundDirector.play(SoundDirector.Mode.teleport);
			}
		
			//otherDoor.SetActive(true);
			director.switchWorlds(otherDoor);
			//director.SaveCheckpoint();


			GameObject obj = Instantiate(TeleportParticleEffect, otherDoor.transform.position,TeleportParticleEffect.transform.rotation) as GameObject;

			//set the particle's rendering to visible against sprites
			obj.particleSystem.renderer.sortingLayerName = this.renderer.name ;
			obj.renderer.sortingOrder = 2;


		//	if (shrink.isOnTheVoid) //if we're on the void, set the current teleporter to the current respawn postions. 
		//	    director.respawnPos = this.transform;

			//StartCoroutine(DeactiveCurrentGameObjectAfterTwoSeconds());
			plr.transform.position = otherDoor.transform.position;
		}
		
	}


	IEnumerator DeactiveCurrentGameObjectAfterTwoSeconds()
	{	
		yield return new WaitForSeconds(0.5f);
		gameObject.SetActive(false);
	}
}
