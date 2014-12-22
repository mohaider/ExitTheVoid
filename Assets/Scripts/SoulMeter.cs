using UnityEngine;
using System.Collections;

public class SoulMeter : MonoBehaviour {
//
//	private float soul =100f;
//	private float maxSoul =100f;
//	private float SoulBar;
//	public GameObject mySoulMeter;
//	public GameObject mySM;
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		float soulpercent = soul / maxSoul;
//		if (soulpercent < 0)
//						soulpercent = 0;
//		if (soulpercent >100)
//			soulpercent = 100;
//		SoulBar = soulpercent * 20;
//	
//		mySM.guiTexture.pixelInset = new Rect (10f, 10f, SoulBar, 5f);
//	}

	public float barDisplay; //current progress
	public Vector2 pos = new Vector2(106,331);
	public Vector2 size = new Vector2(110,12);
	public Texture2D emptyTex;
	public Texture2D fullTex;
	public GUIStyle progress_empty, progress_full;
	private ShrinkPlayer playerSoulPercentage;

	private float totalBar;



	void Start()
	{
		GameObject obj = GameObject.FindGameObjectWithTag ("Player");
		if (obj != null)
			playerSoulPercentage = obj.GetComponent<ShrinkPlayer> (); 
				else if (obj == null)
			Debug.Log ("CANNOT FIND PLAYER");
		}

	void OnGUI() {
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		//GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex, progress_empty);
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		//GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
		GUI.Box(new Rect(0,0, size.x, size.y), fullTex, progress_full);
		GUI.EndGroup();
		GUI.EndGroup();
	}
	
	void Update() {
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever.

		barDisplay = playerSoulPercentage.GetSoulPercentage ();
		//barDisplay = 0.5f;
		//print (barDisplay);
		//        barDisplay = MyControlScript.staticHealth;
	}
	void UpdateSoul(float f)
	{
		totalBar = f;
	}
}
