using UnityEngine;
using System.Collections;

//Just attach this script on a particle that you want to have in reality
//
//
//


public class RealityParticleLayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "RealityDoorWayToVoid";
	}
	

}
