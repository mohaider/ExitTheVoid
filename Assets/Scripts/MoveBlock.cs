using UnityEngine;
using System.Collections;

/// <summary>
/// Behaviour of the movable block
/// </summary>
public class MoveBlock : MonoBehaviour {

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (col.transform.position.x > transform.position.x)
			{
				// move left
				transform.position += Vector3.left * Time.deltaTime;
			}
			else if (col.transform.position.x < transform.position.x)
			{
				// move right
				transform.position += Vector3.right * Time.deltaTime;
			}
		}
	}
}
