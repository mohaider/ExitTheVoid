using UnityEngine;
using System.Collections;

public class MusicDirector : MonoBehaviour {


	public AudioSource voidMusicPlayer;
	public AudioSource realityMusicPlayer;

	public enum mode{voidMusicSound, realityMusicSound};

	void Awake()
	{
		realityMusicPlayer.Pause ();
		}
	public void playMusic(MusicDirector.mode e)
	{
		switch (e)
		{
		case(MusicDirector.mode.realityMusicSound):
			voidMusicPlayer.Pause();
			realityMusicPlayer.Play();
			break;

		case(MusicDirector.mode.voidMusicSound):
			realityMusicPlayer.Pause();
			voidMusicPlayer.Play();
			break;
		default: break;
		}


	}

}
