using UnityEngine;
using System.Collections;

public class ForegroundDebugging : MonoBehaviour {
	private Sprite sp ;
	Vector3[] spriteDim;
	float[] spriteWandH;
	// Use this for initialization
	void Start () {
		// sp = GetComponent<SpriteRenderer>().sprite;

	//	spriteWandH = spriteWidthAndHeight (sp, transform);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Q)) {
			print (Camera.main.pixelWidth);
			print (Camera.main.pixelHeight);
				}
	}

	static Vector3[] SpriteLocalToWorld(Sprite sp, Transform transform) 
	{
		Vector3 pos = transform.position;
		Vector3 [] array = new Vector3[2];
		//top left
		array[0] = pos + sp.bounds.min;
		// Bottom right
		array[1] = pos + sp.bounds.max;
		return array;
	}

	static float[] spriteWidthAndHeight(Sprite sp,Transform t)
	{
		Vector3[] spLocalToWorld = SpriteLocalToWorld (sp,t);
		float[] widthAndHeight = new float[2];
		widthAndHeight [0] = Mathf.Abs (spLocalToWorld[0].x - spLocalToWorld[1].x)*t.localScale.x;
		widthAndHeight [1] = Mathf.Abs (spLocalToWorld[0].y - spLocalToWorld[1].y)*t.localScale.y;
		return widthAndHeight;
	}
}
