using UnityEngine;
using System.Collections;

public class PlayerPositioning : MonoBehaviour {

	GrabAndThrowPieces nilanHoldingPiece;

	// Use this for initialization
	void Start () {
		nilanHoldingPiece = GetComponent<GrabAndThrowPieces>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwitchWorlds(float f)
	{
		SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer> ();
		transform.position = new Vector2 (transform.position.x, transform.position.y + f);
		if (f < 0 ) //in the void, so change the sprite renderer's sorting layer
		{
			//sp.sortingLayerName = "voidPlayer";
			gameObject.renderer.material.SetFloat("_EffectAmount",1f);
			gameObject.renderer.material.SetColor("_Color", new Vector4(158.0f/255f,178.0f/255f,30.0f/255f,1.0f));
		//	nilanHoldingPiece.SwitchPieceSortingLayer();
		}
		else
		{
			//sp.sortingLayerName = "realityPlayer";
			gameObject.renderer.material.SetFloat("_EffectAmount",0.1f);
			gameObject.renderer.material.SetColor("_Color", new Vector4(1f,1f,1f,1.0f));
			//nilanHoldingPiece.SwitchPieceSortingLayer();

		}
	}

	public void SwitchWorlds(GameObject otherPosition, float f)
	{
		SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer> ();
		transform.position = new Vector3 (otherPosition.transform.position.x, otherPosition.transform.position.y, transform.position.z);
		if (f < 0 ) //in the void, so change the sprite renderer's sorting layer
		{
			//sp.sortingLayerName = "voidPlayer"; //no need to change it anymore
			gameObject.renderer.material.SetFloat("_EffectAmount",1f);
			//gameObject.renderer.material.SetColor("_Color", new Vector4(0f,178.0f/255f,30.0f/255f,1.0f));
			//nilanHoldingPiece.SwitchPieceSortingLayer();
		}
		else
		{
			//sp.sortingLayerName = "realityPlayer";
			gameObject.renderer.material.SetFloat("_EffectAmount",0.1f);
			//gameObject.renderer.material.SetColor("_Color", new Vector4(1f,1f,1f,1.0f));
			//nilanHoldingPiece.SwitchPieceSortingLayer();
			
		}
	}
}
