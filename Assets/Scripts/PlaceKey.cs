using UnityEngine;
using System.Collections;

/// <summary>
/// Script to place key in one of the key place holders
/// </summary>
public class PlaceKey : MonoBehaviour {

	public GameObject key;

	private GameObject[] keyPlaceholders;

	void Start () {
		if (key == null)
		{
			print ("KEY NOT DEFINED. DISABLING KEY PLACING.");
			this.enabled = false;
		}

		keyPlaceholders = GameObject.FindGameObjectsWithTag ("KeyPlaceholder");

		int i = Random.Range (0, keyPlaceholders.Length - 1);
		Instantiate (key, keyPlaceholders [i].transform.position, key.transform.rotation);
	}
}
