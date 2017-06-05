using UnityEngine;
using System.Collections;

public class PinControl : MonoBehaviour {

	GameObject myBowlingBall;
	bool isPlaySound;


	void Start () {
		myBowlingBall = GameObject.Find ("BowlingBall");
	}
	
	void Update () {
		
		if (myBowlingBall.transform.position.z > 0 && !this.GetComponent<AudioSource> ().isPlaying) {
			this.GetComponent<AudioSource> ().Play ();
		}

		if (myBowlingBall.transform.position.z > 30) {
			this.GetComponent<AudioSource> ().volume += -.1f * Time.deltaTime;

			if (this.GetComponent<AudioSource> ().volume <= 0) {
				this.GetComponent<AudioSource> ().Stop ();
			}
		}
	}
}
