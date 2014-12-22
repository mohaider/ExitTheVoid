using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public string nextLevelName;
	public string nextLevelTitle;
	public int nextLevelNumber;
	//public GameObject nextLevelRepresentation;
	
	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D plr)
	{
		print ("ready to exit");
		if (plr.gameObject.tag == "Player" && Input.GetButtonDown("Interact"))
		{	
			print ("Now Exiting");
			LevelSettings.instance.levelName = nextLevelName;
			LevelSettings.instance.levelTitle = nextLevelTitle;
			LevelSettings.instance.levelNumber = nextLevelNumber;
			//LevelSettings.instance.levelRepresentation = nextLevelRepresentation;
			Application.LoadLevel("StartLevelScreen");
		}
		
	}
}
