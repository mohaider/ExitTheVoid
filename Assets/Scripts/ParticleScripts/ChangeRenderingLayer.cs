using UnityEngine;
using System.Collections;

public class ChangeRenderingLayer : MonoBehaviour {
	public string sortingLayer;
	public int sortingOrder;
	// Use this for initialization
	void Awake () {
		particleSystem.renderer.sortingLayerName =sortingLayer ;
		particleSystem.renderer.sortingOrder = this.sortingOrder;
	}
	
	// Update is called once per frame
	void Update () {
		particleSystem.renderer.sortingLayerName =sortingLayer ;
		particleSystem.renderer.sortingOrder = this.sortingOrder;

	}
}
