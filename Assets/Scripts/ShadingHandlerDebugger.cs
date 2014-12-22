using UnityEngine;
using System.Collections;

public class ShadingHandlerDebugger : MonoBehaviour {
	Vector4 nextColor ;
	public int cyclicalFrequency =9;
	public float expPower = 2f;

	// Use this for initialization
	void Start () {
		nextColor = new Vector4 (1f, 1f, 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		//Flicker ();
	
	}

	void Flicker()
	{
		float flickerFrequency = Mathf.Pow (2f, Time.time/3f);

//		gameObject.renderer.material.SetFloat("_EffectAmount",1f);
//		float closeToTransparent = 0.1f;
//		 nextColor = Vector4.Lerp( 
			// new Vector4 (137f / 255f, 138f / 255f, 1f, 111f);
		bool isFlashingRapidly = ((int)(flickerFrequency *cyclicalFrequency) % 2 == 0 );
		nextColor.w = isFlashingRapidly ? 0.75f : 0.25f;
		gameObject.renderer.material.SetColor("_Color",nextColor);

	}
}
