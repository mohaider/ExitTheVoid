using UnityEngine;
using System.Collections;

public class SoundDirector : MonoBehaviour {
	public AudioClip pickupSound;
	public AudioClip placeSound;
	public AudioClip unlockSound;
	public AudioClip openSound;
	public AudioClip teleportSound;
	public AudioClip successSound;
	public AudioClip eventSuccessSound;
	public AudioClip elevatorArrivalSound;
	public AudioClip keyPickerSound;

	public enum Mode { pickup, place, unlock, open, teleport, success,eventSuccess,elevatorArrival, keyPicker  };



	public void play(SoundDirector.Mode sound)
	{
	switch(sound)
		{
		case(SoundDirector.Mode.pickup):
			audio.clip = pickupSound;
			audio.Play();
			break;
		case(SoundDirector.Mode.place):
			audio.clip = placeSound;
			audio.Play();
			break;
		case(SoundDirector.Mode.unlock):
			audio.clip = unlockSound;
			audio.Play();
			break;
		case(SoundDirector.Mode.open):
			audio.clip = openSound;
			audio.Play();
			break;
		case(SoundDirector.Mode.teleport):
			audio.clip = teleportSound;
			audio.Play();
			break;
		case(SoundDirector.Mode.success):
			audio.clip = successSound;
			audio.Play();
			break;
		case(SoundDirector.Mode.eventSuccess):
			audio.clip = eventSuccessSound;
			audio.Play ();
			break;
		case(SoundDirector.Mode.elevatorArrival):
			audio.clip=elevatorArrivalSound;
			audio.Play ();
			break;

		case(SoundDirector.Mode.keyPicker):
			audio.clip = keyPickerSound;
			audio.Play ();
			break;


		
		default:
			break;



		}



	}
}
