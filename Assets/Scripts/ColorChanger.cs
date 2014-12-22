using UnityEngine;
using System.Collections;

public class ColorChanger  {

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
	public GameObject lowsoulWarning ;



	public ColorChanger(GameObject lowsoulWarning)
	{
		this.lowsoulWarning = lowsoulWarning;

	}
}
