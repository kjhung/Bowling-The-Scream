using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour {

	GameObject myAdjustSign;
	GameObject myArrowSign;
	GameObject myChargingBar;
	AudioSource [] myBowlingSound;

	float maxForce;
	float launchForce;
	float addonForce;
	bool isBallReady;
	public bool isBallGo;

	void Start () {
		maxForce = 50000;
		launchForce = 10000;
		addonForce = 20000;
		isBallReady = false;
		isBallGo = false;

		this.GetComponent<Rigidbody> ().useGravity = false;
		myAdjustSign = GameObject.Find ("AdjustSign");
		myArrowSign = GameObject.Find ("ArrowSign");
		myChargingBar = GameObject.Find ("ChargingBar");
		myBowlingSound = GetComponents<AudioSource> ();
	}

	void Update () {
		if (!isBallGo) {
			if (Input.GetKey ("space")) {
				myAdjustSign.SetActive (false);
				myArrowSign.SetActive (false);

				isBallReady = true;
				launchForce += addonForce * Time.deltaTime;

				myChargingBar.GetComponent<Image> ().fillAmount = (launchForce / maxForce);

				if (launchForce > maxForce) {
					launchForce = addonForce;
				}
			}

			if (Input.GetKeyUp ("space")) {
				if (isBallReady) {
					isBallGo = true;
					this.GetComponent<Rigidbody> ().useGravity = true;
					this.GetComponent<Rigidbody> ().AddForce (launchForce * transform.forward);

					myChargingBar.GetComponent<Image> ().fillAmount = 0;
					myBowlingSound [1].Play ();
					myBowlingSound [0].Play ();
				}
			}

			if (myBowlingSound [1].isPlaying) {
				myBowlingSound [1].volume += -.3f * Time.deltaTime;
			}
		}
	}
}
