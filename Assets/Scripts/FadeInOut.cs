using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {
	public float fadeSpeed = 1.5f; //how quickly the screen fades in and out

	private bool sceneStart = true;


	void Awake()
	{
		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);


	}

	void Update()
	{
		if (sceneStart) {
						StartScene ();
				}
	}

	void FadeToclear()
	{
		guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	void FadeToBlack()
	{
		guiTexture.color = Color.Lerp (guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
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
		guiTexture.enabled = true;
		FadeToBlack ();

		if (guiTexture.color.a >= 0.95f) {
			Application.LoadLevel(0);		
		}
	}

}
