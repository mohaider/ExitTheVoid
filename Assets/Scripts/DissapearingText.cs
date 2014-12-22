using UnityEngine;
using System.Collections;

public class DissapearingText : MonoBehaviour {

	public float DURATION = 2.5f;
	Color OriginalColor ;
	Color newColor;
	private float timer = 0f;

	void Awake()
	{
		Color OriginalColor = guiText.material.color;
	}

	void OnEnable()
	{

		Color newColor = OriginalColor;

	}

	void Update() {
		newColor = guiText.material.color;
		if( DURATION< timer){
			timer = 0f;
			gameObject.SetActive(false);

		}

		float proportion = (timer / DURATION);
		newColor.a = Mathf.Lerp(1, 0, proportion);
		guiText.material.color = newColor;

		timer += Time.deltaTime; 
	}
}

