using UnityEngine;
using System.Collections;

/// <summary>
/// Scripts that holds the key to the door or the enemy cage
/// </summary>
public class Holder : MonoBehaviour {

	public Texture keyTexture;
	public Texture cageTexture;
	public Texture emptyTexture;
	public GameObject objectTexture;
	public bool hasKey = false;
	public bool hasCage = false;
	public GameObject cagePE;
	public GameObject keyPE;

	private GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

		if (cagePE == null)
			cagePE = new GameObject();
		if (keyPE == null)
			keyPE = new GameObject();

		objectTexture.SetActive(true);
	}

	void Update () {
		if (hasKey)
		{
			// Show key texture
			objectTexture.guiTexture.texture = keyTexture;
			objectTexture.SetActive(true);
			//objectTexture.guiTexture.pixelInset= new Rect(480,470, -400,-300);
		}
		else if (hasCage)
		{
			// Show cage texture
			objectTexture.guiTexture.texture = cageTexture;
			objectTexture.SetActive(true);
		}
		else
		{
			objectTexture.guiTexture.texture = emptyTexture;
			//objectTexture.SetActive(false);
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetButtonDown("Interact"))
		{
			if (col.gameObject.tag == "Key")
			{
				hasKey = true;
				Instantiate(keyPE, col.transform.position, keyPE.transform.rotation);
				GameObject.FindGameObjectWithTag("SoundDirector").GetComponent<SoundDirector>().play(SoundDirector.Mode.keyPicker);
				Destroy(col.gameObject);
			}
			if (col.gameObject.tag == "Cage")
			{
				hasCage = true;
				//cageTexture = col.gameObject.guiTexture.texture;
				player.GetComponent<TrapEnemy>().cage = col.gameObject;
				Instantiate(cagePE, col.transform.position, keyPE.transform.rotation);
				//Destroy(col.gameObject);
				col.gameObject.transform.position += Vector3.right * 1000;
			}
		}
	}
}
