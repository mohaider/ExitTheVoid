using UnityEngine;
using System.Collections;

public class NilansVoice : MonoBehaviour {

	public AudioClip deathSound;
	public AudioClip lowSoulSound;

	public enum Mode { death,lowsoul };

	public void playSound(NilansVoice.Mode e)
	{
		switch(e)
		{
		case(NilansVoice.Mode.death):
			audio.clip = deathSound;
			audio.Play();
			break;
		case(NilansVoice.Mode.lowsoul):
			audio.clip = lowSoulSound;
			audio.Play ();
			break;
		default:
			break;
		}


	}
}
