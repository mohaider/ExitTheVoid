using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public float fadeSpeed = 1.5f; //how quickly the screen fades in and out
	
	private bool sceneStart = true;
	public AudioClip enterSound;
	public GameObject exitvoid;
	public GameObject pressenter;
	bool enterPressed =false;
	bool finishedLerping = false;
	void Awake()
	{
		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
		
		
	}
	
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Return) ) {
	
			audio.clip = enterSound;
			audio.Play ();
			enterPressed =true;
				}
		if (enterPressed) {
			FadeToBlack ();	
		}
	}
	
	void FadeToclear()
	{
		guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	void FadeToBlack()
	{
		guiTexture.color = Color.Lerp (guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
		Color exitVoidCol = exitvoid.GetComponent<GUIText> ().color;
		exitvoid.GetComponent<GUIText>().color = Color.Lerp (exitVoidCol, Color.black, fadeSpeed * Time.deltaTime);
		pressenter.GetComponent<GUIText>().color = Color.Lerp (exitVoidCol, Color.black, fadeSpeed * Time.deltaTime);
		if (guiTexture.color.a >= 0.99f)
			Application.LoadLevel(1);

	}
	
	void StartScene()
	{
		FadeToclear ();
		
		if (guiTexture.color.a <= 0.05f) 
		{
			guiTexture.color =Color.clear;
			guiTexture.enabled = false;
			sceneStart =false; 
			
		}
	}
	
	public void EndScene()
	{
		//guiTexture.enabled = true;
		//FadeToBlack ();
		
		if (guiTexture.color.a >= 0.95f) {
			{
			
					Application.LoadLevel(1);	
			}	
		}
	}
}
