using UnityEngine;
using System.Collections;

public class Layer0_parallax : MonoBehaviour {
	private PlayerControl player;
	//public Color _tint;
	public float distance;

	private const float MAX_DIST= 80f;
	private float _parallaxFactor;

	private Vector3 _cameraRefPosition;
	private Transform _cameraTransform;
	private tk2dSprite[] _layerObjects;


	// Use this for initialization
	void Start () {
		_layerObjects = GetComponentsInChildren<tk2dSprite>();
//		
//		for (int i = 0; i < _layerObjects.Length; ++i)
//		{
//			_layerObjects[i].color = _tint;
//		}
//		
		_parallaxFactor = distance / MAX_DIST;
		
		if (_parallaxFactor > 1)
		{
			_parallaxFactor = 1f;
		}
		if (Camera.main) {
						_cameraRefPosition = Camera.main.GetComponent<Camera2DFollow> ().referencePosition;
			print (_cameraRefPosition);

			_cameraTransform = Camera.main.transform;

				} else
						print ("couldn't find the camera");

	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (player.speed * _parallaxfactor * Time.deltaTime);

		Vector3 cameraDisplacement = (_cameraTransform.position - _cameraRefPosition) * _parallaxFactor;
		
		cameraDisplacement.z = distance;

		transform.position = cameraDisplacement;
	}
}
