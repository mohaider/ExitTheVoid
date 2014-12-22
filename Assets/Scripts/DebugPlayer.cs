using UnityEngine;
using System.Collections;

public class DebugPlayer : MonoBehaviour {
	public float distance = 20f;
	private bool ShowControls = false;
	private float verticalScaler = 1f;
	private bool goingUp =true;
	Vector3 voidPosition;
	private bool disableShrink =true;
	HintBoxController hintbox;
	ShrinkPlayer shrink;

	string controls = "Debug Menu " +
		"\n numPad 5: switch between void and reality" +
		"\n numpad 4: quickly move left " +
		"\n numpad 2: quickly move down" +
		"\n numpad 6: quickly move right" +
		"\n numpad 8: quickly move up" +
		"\n F1:     : disable/enable shrinking" +
		"\n F2:     : Speed up shrinking" +
		"\n F3:     : Slowdown shrinking" +
		"\n ESC:    : enable/disable debug controls";


	void Awake()
	{
		voidPosition = new Vector3 (148f, -4.6f, 0);
		GameObject temp = GameObject.FindGameObjectWithTag ("HintBox");
		
		if( ErrorWindow<DebugPlayer>.CanBeAssigned (temp,this, "HintBox")) 
			hintbox=temp.GetComponent<HintBoxController> ();

		shrink = GameObject.FindGameObjectWithTag ("Player").GetComponent<ShrinkPlayer> ();

		}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Keypad5)) {
				if (goingUp)
					{
						transform.position = Vector3.up * 400;
				goingUp = false;
					}
			else 
			{
				transform.position = voidPosition;
				goingUp = true;
			}
				
			
				}

		if (Input.GetKey (KeyCode.Keypad4))
			transform.position = transform.position - Vector3.right * distance;
		if (Input.GetKey (KeyCode.Keypad6))
			transform.position = transform.position + Vector3.right * distance;
		if (Input.GetKey (KeyCode.Keypad8))
			transform.position = transform.position + Vector3.up * distance;
		if (Input.GetKey (KeyCode.Keypad2))
			transform.position = transform.position - Vector3.up * distance;
	
		if (Input.GetKeyDown(KeyCode.F1))
		{
			if(disableShrink)
			{
				GetComponent<ShrinkPlayer>().enabled = false;
				disableShrink = false;
			}
			else
			{
				GetComponent<ShrinkPlayer>().enabled = true;
				disableShrink = true;

			}
		}
		if (Input.GetKeyDown(KeyCode.F2))
		{
			shrink.shrinkingSpeed += 0.001f;
		}
		if (Input.GetKeyDown(KeyCode.F3))
		{
			shrink.shrinkingSpeed -= 0.001f;
		}
		if (Input.GetKeyDown(KeyCode.F4))
		{
			shrink.shrinkingSpeed = 0f;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (ShowControls)
			{
				hintbox.UseMessageBox(this.gameObject,HintBoxController.Mode.activateMessage,controls);
				ShowControls =false;
			}
			else
			{
				hintbox.UseMessageBox(this.gameObject,HintBoxController.Mode.deactivateTextBox,controls);
				ShowControls =true;
			}
		}
	
	}




}
