using UnityEngine;
using System.Collections;

public class playNote : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//float is volume
	void PlayThis(System.Object[] args)
	{

		audio.clip = args[0] as AudioClip;
		audio.volume = (float)args [1] ;
		audio.Play ();
	}
}
