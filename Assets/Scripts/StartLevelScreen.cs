using UnityEngine;
using System.Collections;

/// <summary>
/// Start level screen.
/// </summary>
public class StartLevelScreen : MonoBehaviour {

	public GameObject levelRepresentationPlace;
	public int levelNumber;
	public GameObject levelText;
	public GameObject levelTitle;
	public GameObject pressEnter;
	public AudioClip enterSound;
//	public GameObject representation;

	public float fadeSpeed = 1.5f; //how quickly the screen fades in and out

	private bool enterPressed = false;
	private LevelSettings levelSettings;

	void Awake()
	{
		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
	}

	void Start () 
	{
		StartScene ();
		levelSettings = GameObject.FindObjectOfType<LevelSettings> ();
		print (levelSettings.name);
		levelText.guiText.text = LevelSettings.instance.levelName;
		levelTitle.guiText.text = LevelSettings.instance.levelTitle;
		levelNumber = LevelSettings.instance.levelNumber;
//		representation = LevelSettings.instance.levelRepresentation;
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Return) ) 
		{
			audio.clip = enterSound;
			audio.Play ();
			enterPressed = true;
		}

		if (enterPressed) {
			FadeToBlack ();
			//StartLevel();
		}
	}

	void StartScene()
	{
//		Instantiate (representation, levelRepresentationPlace.transform.position, representation.transform.rotation);

		FadeToclear ();
		
		if (guiTexture.color.a <= 0.05f)
		{
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
		}
	}

	void StartLevel()
	{
		Application.LoadLevel (levelNumber + 1);
	}

	void FadeToclear()
	{
		guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	void FadeToBlack()
	{
		guiTexture.color = Color.Lerp (guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
		Color exitVoidCol = levelText.GetComponent<GUIText> ().color;
		levelText.GetComponent<GUIText>().color = Color.Lerp (exitVoidCol, Color.black, fadeSpeed * Time.deltaTime);
		levelTitle.GetComponent<GUIText>().color = Color.Lerp (exitVoidCol, Color.black, fadeSpeed * Time.deltaTime);
		pressEnter.GetComponent<GUIText>().color = Color.Lerp (exitVoidCol, Color.black, fadeSpeed * Time.deltaTime);
		if (guiTexture.color.a >= 0.99f)
			Application.LoadLevel (levelSettings.levelNumber);
	}
}
