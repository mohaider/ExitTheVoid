using UnityEngine;
using System.Collections;

/// <summary>
/// Script used to trap enemy using cage
/// </summary>
public class TrapEnemy : MonoBehaviour {

	private GameObject player;
	private string hint;
	private string flashingTextMsg;
	private HintBoxController hintBox;
	private FlashingTextController flashText;
	private bool hasAlreadyInteracted = false;

	public GameObject cage;

	void Awake()
	{
		hintBox = GameObject.FindGameObjectWithTag ("HintBox").GetComponent<HintBoxController> ();
		flashText = GameObject.FindGameObjectWithTag ("FlashingTextBox").GetComponent<FlashingTextController> ();
		hint = "You need a cage to trap the enemy.";
		flashingTextMsg = "Press e";
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.gameObject.tag == "MonsterRegion") && (!hasAlreadyInteracted))
		{
			flashText.UseFlashMsg(gameObject, FlashingTextController.Mode.activateMessage, flashingTextMsg);
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "MonsterRegion")
		{
			if (Input.GetButtonDown("Interact"))
			{
				if (player.GetComponent<Holder>().hasCage)
				{
					// Traps enemy
					flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.permanentlyDeactivateFlash,"");
					Instantiate(cage, col.gameObject.transform.position, cage.transform.rotation);
					col.gameObject.transform.parent.GetComponent<MonsterBehaviour>().enabled = false;
					col.gameObject.transform.parent.GetComponent<Animator>().enabled = false;
					col.gameObject.transform.parent.gameObject.collider2D.enabled = false;
					col.gameObject.transform.parent.gameObject.tag = "Untagged";
					col.gameObject.transform.parent.gameObject.rigidbody2D.gravityScale = 0f;
					player.GetComponent<Holder>().hasCage = false;
					// Open exit tunnel
					GameObject.FindGameObjectWithTag("Director").GetComponent<Director>().FinishedLevel();
				}
				else
				{
					// hint box
					flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.permanentlyDeactivateFlash,"");
					hasAlreadyInteracted = true;
					hintBox.UseMessageBox(gameObject, HintBoxController.Mode.activateMessage, hint);
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		flashText.UseFlashMsg(gameObject,FlashingTextController.Mode.deactivateFlashText,"");
		hintBox.UseMessageBox(gameObject,HintBoxController.Mode.deactivateTextBox,hint);
	}
}
