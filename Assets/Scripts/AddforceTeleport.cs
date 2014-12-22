using UnityEngine;
using System.Collections;

public class AddforceTeleport : MonoBehaviour {


	
	public GameObject otherDoor;
	
	public GameObject TeleportParticleEffect;

	private bool hasTeleported =false;
	private GameObject player;
	public GameObject camera;



	void FixedUpdate()
	{

	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{	
			print ("hitting the " + gameObject.name+" teleporter");
			TeleportToOtherDoor (col.gameObject);
		}
	}
	
	void TeleportToOtherDoor(GameObject plr)
	{
		
		if (Input.GetButtonDown("Interact"))
		{	
			
			plr.gameObject.transform.position = otherDoor.transform.position;
			player = plr.gameObject;
			Vector2 vel = player.rigidbody2D.velocity;
			vel.y = 0;
			player.rigidbody2D.velocity = vel;
			player.rigidbody2D.AddForce(Vector2.up*2500f);
			GameObject obj = Instantiate(TeleportParticleEffect, otherDoor.transform.position,Quaternion.identity) as GameObject;
			Vector3 otherPos =otherDoor.transform.position;
			otherPos.z = -10;
			camera.transform.position = otherPos;
			
		}
		
	}
}
