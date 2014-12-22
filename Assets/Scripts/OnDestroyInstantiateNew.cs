using UnityEngine;
using System.Collections;

public class OnDestroyInstantiateNew : MonoBehaviour {
	public GameObject portal;
	// Use this for initialization
	void OnDestroy()
	{
		portal.SetActive (true);
	}
}
