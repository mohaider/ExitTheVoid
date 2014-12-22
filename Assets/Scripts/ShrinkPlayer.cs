using UnityEngine;
using System.Collections;

/// <summary>
/// Shrink the player in the real world and put it back to normal in the void
/// </summary>
public class ShrinkPlayer : MonoBehaviour {

	// Controls where the player is
	 public bool isOnTheVoid = true;
	public Font font;
	public float shrinkingSpeed = 0.01f;
	public GameObject soulmeter;

	public GameObject deathPS;
	private Director director;
	public GameObject soulText;
	private float shrinkScalar =1f;
	public GameObject replenishSoulEffect;

	private float flashTimer = 0f;
	//public GameObject SoulMeterPercentage;
	//private ShadingHandler ;
	private ColorChanger colorChanger;
	// GUI elements
	private Rect lblScore;
	private ShadingHandler shade;
	public NilansVoice nilansVoice;

	private float lowSoulTimer=0.4f;




	void Awake () {
	
		GameObject obj = GameObject.FindGameObjectWithTag ("Director");
		if (obj == null)
						Debug.Log ("Director obj not found");
				else 
			
						director = obj.GetComponent<Director> ();

		gameObject.SendMessage ("SetTransparencySpeed",shrinkingSpeed);

		soulmeter = GameObject.FindGameObjectWithTag ("Soulmeter");

	
			
		shade = GetComponent<ShadingHandler> ();


	}
	
	void Update () {
	
		if (flashTimer < 0) {
			shrinkScalar = 1.0f;
			replenishSoulEffect.SetActive(false);
		}
		if (flashTimer >= 0) {
			shrinkScalar  = 3f;
			replenishSoulEffect.SetActive(true);
		}

		if (isOnTheVoid)
		{
			UpdateInVoidText();

			if (transform.localScale.x < 1f)
			{
				transform.localScale = new Vector3(transform.localScale.x + (shrinkScalar*shrinkingSpeed * Time.deltaTime), transform.localScale.y + (shrinkScalar * shrinkingSpeed * Time.deltaTime), 
				                                   transform.localScale.z);
				//SoulMeterPercentage.SetActive(false);
				if(Input.GetKey(KeyCode.R))
				{
					flashTimer = 1.75f;
					//
				//	
				}
				shade.LerpToVoidColor();

			}
			if (transform.localScale.x >=1f)
				transform.localScale =Vector3.one;
			shade.Warning(false);

			//



		}
		else
		{
			//SoulMeterPercentage.SetActive (true);
			// In the real world
			// Shrinks the representation in the soulmeter
			transform.localScale = new Vector3(1f,1f,1f);
			if (soulmeter.transform.localScale.x >= 0.2f)
			{
				soulmeter.transform.localScale = new Vector3(soulmeter.transform.localScale.x - (shrinkingSpeed * Time.deltaTime), 
				                                                   soulmeter.transform.localScale.y - (shrinkingSpeed * Time.deltaTime), transform.localScale.z);
				UpdateInRealityText();
				shade.LerpToRealityColor();
				if (soulmeter.transform.localScale.x <= 0.5f)
				{
					shade.Warning(true);
					lowSoulTimer -=Time.deltaTime;
					if(lowSoulTimer<0 && nilansVoice != null)
					{
						lowSoulTimer =0.4f;
						nilansVoice.playSound (NilansVoice.Mode.lowsoul);

					}
				}

			}
			else
			{
				
//				// Dead
//				Destroy(this.gameObject,5f);
//				// Death effects
//				GameObject obj = Instantiate(deathPS, transform.position, Quaternion.identity) as GameObject;
//				//obj.particleSystem.renderer.sortingLayerName = "realityForeground";
//			//	obj.renderer.sortingOrder = -1;
//				// Sends message for the director to restart the level

				if(nilansVoice != null)
				{

					nilansVoice.playSound(NilansVoice.Mode.death);
				}
				shade.ResetToVoidColor();
				director.PlayerIsDead();
				isOnTheVoid =true;
			
			}

		}
		flashTimer -= Time.deltaTime;
	}
	void UpdateInRealityText()
	{
		float soulP =  Mathf.Round( (map (soulmeter.transform.localScale.x - 0.2f,0f,1f,0f,125f))); 
		soulText.guiText.text = soulP + " percent soul Left" ;
	}

	void UpdateInVoidText()
	{
		
		float soulP =  Mathf.Round( (map (transform.localScale.x - 0.2f,0f,1f,0f,125f))); 
		soulText.guiText.text = soulP +" percent soul Left" ;
		}




	public float GetSoulPercentage()
	{

		return 	((soulmeter.transform.localScale.x -.2f) );
	}
	

	public bool OnVoid()
	{
		return isOnTheVoid;
	}

//	void OnGUI()
//	{
//		GUIStyle style = new GUIStyle ();
//		style.normal.textColor = Color.black;
//		style.font = font;
//		if (!isOnTheVoid)
//			GUI.Label (lblScore, "SOULMETER " + ((soulmeter.transform.localScale.x - 0.2f) * 125).ToString("0.00"));
//	}
	float map(float val, float inMin, float inMax, float outMin, float outMax)
	{
		
		return outMin + (outMax - outMin) * ((val - inMin) / (inMax - inMin)); 
	}
}
