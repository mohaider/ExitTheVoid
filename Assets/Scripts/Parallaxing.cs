using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {
	
	public Transform[] backgrounds; //list of all back and foregrounds to be parrallaxed
	private float[] parallaxScales; //proportions of the cameras movement to move the backgrounds by...
	public float smoothing =1f;			//how smooth the parallax is going to be. Make sure to set this above 0.
	private Transform cam;				//reference to the main camera's transform
	private Vector3 previousCamPosition;//will store the position of the camera in the previous frame. will be used for calculation of parallaxing
	
	void Awake()//great for reference between GameObjects and variables
	{
		//set up the camera reference
		cam = Camera.main.transform;
		
	}
	// Use this for initialization
	void Start () {
		//store the previous frame. this had the current frame's camera position
		previousCamPosition = cam.position;
		parallaxScales = new float[backgrounds.Length];
		
		//assign corresponding parallax scales
		for (int i =0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z * -1f;		
		}
		
		//for each background
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i =0; i < backgrounds.Length; i++) {
			
			//the parallax is the opposite of the camera movement from  the previous frame multiplied by the scale
			float parallax= (previousCamPosition.x - cam.position.x)* parallaxScales[i];
			
			//set a target x position which is the current position plus the parallax 
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;
			
			//create a targt position which is the background current position with it's target x position
			Vector3 backgroundTargetPos =  new Vector3 (backgroundTargetPosX, backgrounds[i].position.y,  backgrounds[i].position.z);
			
			//fade beween current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
			
		} 
		//set the previous cam position to the camera's position at the end of the frame
		previousCamPosition = cam.position;
		
	}
}
