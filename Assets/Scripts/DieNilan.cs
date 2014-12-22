using UnityEngine;
using System.Collections;

public class DieNilan : MonoBehaviour {
	Director director;

	void Start()
	{
		GameObject obj = GameObject.FindGameObjectWithTag ("Director");
		if (obj == null)
						Debug.Log ("dieNilan cannot find director in game");
				else
						director = obj.GetComponent<Director> ();

	}

void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			director.PlayerIsDead();
		}


	}
}
