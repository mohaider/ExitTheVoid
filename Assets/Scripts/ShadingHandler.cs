using UnityEngine;
using System.Collections;

public class ShadingHandler : MonoBehaviour {

	private Vector4 nextColor;			//
	private Vector4 originalColor;		//original Color
	private Vector4 colorOfDeath;		//colorToLerpTo
	public float transparencySpeed = 0.5f; //variable to determine how fast a character becomes transparent
	public bool inDebugMode = true;
	private float transColor = 1.0f;

	private bool startChangingColors = false;
	private bool flicker = false;
	public int cyclicalFrequency =9;
	public float expPower = 2f;
	float flickeringTime = 0f;
	float playLowSoulSoundTimer;
	public GameObject lowsoulWarning ;
	ShrinkPlayer shrink;
	

	// Use this for initialization
	void Start () {
		shrink = GetComponent<ShrinkPlayer> ();
		originalColor = new Vector4 (1f, 1f, 1f, 1f);
		nextColor = new Vector4 (1f, 1f, 1f, 1f);
		colorOfDeath = new Vector4 (208f / 255f, 116f / 255f, 240f / 255f, 0.5f);
		//nextColor = new V

	}
	
	// Update is called once per frame
	void Update () {


//		if (shrink.isOnTheVoid ){//&& startChangingColors) {
//			LerpToVoidColor();
//		}
//
//		if (!shrink.isOnTheVoid ) {
//			LerpToRealityColor();
//				}

	}

	public void LerpToVoidColor()
	{
	
		//nextColor = Vector4.Lerp (nextColor, originalColor, Time.deltaTime * transparencySpeed);
		//gameObject.renderer.material.SetColor ("_Color",nextColor);
		gameObject.renderer.material.SetColor ("_Color",originalColor);
		gameObject.renderer.material.SetFloat("_EffectAmount",1f);
		//if the color is really close to its original color, then set the current color back to its original color
	//	if (Vector4.Distance(nextColor,originalColor) >= 0.8f * Vector4.Distance(originalColor,colorOfDeath))
	//	{

		//	nextColor = originalColor;
			startChangingColors =false;
			flickeringTime = 0f;
		//	gameObject.renderer.material.SetColor ("_Color",nextColor);

		//}
	}
	public void ResetToVoidColor()
	{
		nextColor = originalColor;
		gameObject.renderer.material.SetColor ("_Color",originalColor);
		gameObject.renderer.material.SetFloat("_EffectAmount",1f);

	}

	public void LerpToRealityColor()
	{
	
		gameObject.renderer.material.SetFloat("_EffectAmount",0f);
		//if not flickering, don't flicker
		if (!flicker)
		{	
			nextColor = Vector4.Lerp (nextColor, colorOfDeath, Time.deltaTime * transparencySpeed);
			//if the color's distance is 50% away from the distance of the original color to the color of death
			//then start flickering rapidly 

		}



		gameObject.renderer.material.SetColor ("_Color",nextColor);

	}

	public void Warning(bool flicker)
	{
		if (flicker) 
		{
			flickeringTime += Time.deltaTime;
			
			bool isFlashingRapidly = ((int)(flickeringTime *cyclicalFrequency) % 2 == 0 );
			nextColor.w = isFlashingRapidly ? 0.75f : 0.5f;
			nextColor = Vector4.Lerp (nextColor, colorOfDeath, Time.deltaTime * transparencySpeed);
			lowsoulWarning.SetActive (true);
		}
		else 
			lowsoulWarning.SetActive (false);
	}


	float returnDelta()
	{
		return Time.deltaTime;
		}


	void SetTransparencySpeed(float tSpeed)
	{
		transparencySpeed = tSpeed *2f;

	}



	public void SwitchWorlds(float f)
	{
		SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer> ();
		transform.position = new Vector2 (transform.position.x, transform.position.y + f);

		if (f < 0 ) {
			gameObject.renderer.material.SetFloat("_EffectAmount",1f);
			gameObject.renderer.material.SetColor("_Color", new Vector4(158.0f/255f,178.0f/255f,30.0f/255f,1.0f));
			print ( "1. current _color is " +gameObject.renderer.material.GetColor ("_Color"));
		}

		else
		{
			gameObject.renderer.material.SetFloat("_EffectAmount",0.1f);
			gameObject.renderer.material.SetColor("_Color", new Vector4(1f,1f,1f,1.0f));
			print ("2. current _color is " +gameObject.renderer.material.GetColor ("_Color"));
		}
	}
	
	public void SwitchWorlds(GameObject otherPosition, float f)
	{
		SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer> ();
		transform.position = new Vector3 (otherPosition.transform.position.x, otherPosition.transform.position.y, transform.position.z);
		if (f <0) 
		{
			gameObject.renderer.material.SetFloat("_EffectAmount",1f);
			//shrink.isOnTheVoid = true;
			flicker = false;
			print ("3.current _color is " +gameObject.renderer.material.GetColor ("_Color"));

		}
		else
		{
			gameObject.renderer.material.SetFloat("_EffectAmount",0f);

			startChangingColors = true; //once were in reality, we set this variable to true so that when we're back to the void we can start lerping towards this color
			print (".current _color is " +gameObject.renderer.material.GetColor ("_Color"));
		}
	}

	public void setChangingColorTotrue()
	{
		startChangingColors = true;

	}
}
