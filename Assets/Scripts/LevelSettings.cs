using UnityEngine;
using System.Collections;

/// <summary>
/// Save the level settings using the singleton pattern
/// </summary>
public class LevelSettings : MonoBehaviour {

	private static LevelSettings _instance;

	public static LevelSettings instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<LevelSettings>();
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	public string levelName;
	public string levelTitle;
	public int levelNumber;
	public GameObject levelRepresentation;
	public AudioClip levelAudio;

	void Awake () {
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			if (this != _instance)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
