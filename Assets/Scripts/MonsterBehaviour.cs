using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the behaviour of the monster
/// </summary>
public class MonsterBehaviour : MonoBehaviour {

	// Limits of movement
	private Vector3 rightLimit;
	private Vector3 leftLimit;

	private Vector3 movementVector;

	private GameObject player;

	private GameObject director;

	public float speed = 4f;
	public GameObject cage;

	public AudioClip nilanDies;

	void Start () {
		rightLimit = transform.position + (Vector3.right * 5);
		leftLimit = transform.position + (Vector3.left * 5);

		movementVector = Vector3.left;

		player = GameObject.FindGameObjectWithTag ("Player");
		director = GameObject.FindGameObjectWithTag ("Director");

		if (cage == null)
		{
			print ("CAGE NOT AVAILABLE. DISABLING MONSTER");
			//this.enabled = false;
		}
	}
	
	void Update () {
		transform.position += (movementVector * speed * Time.deltaTime);
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			// Player dies
			director.GetComponent<Director>().PlayerIsDead();
			audio.clip = nilanDies;
			audio.Play ();
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// Checks the bounds for the monster movement
		if (col.gameObject.tag == "MonsterBoundary")
		{
			transform.Rotate(0f, 180f, 0f);
			movementVector *= (-1);
		}
	}
}
