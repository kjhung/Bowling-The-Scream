using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowRestartText : MonoBehaviour {

	GameObject myBowlingBall;
	Image myRestartSign;
	bool isSignDisplay = false;

	void Start () {
		myBowlingBall = GameObject.Find("BowlingBall");
		myRestartSign = GameObject.Find ("RestartSign").GetComponentInChildren<Image> ();
		myRestartSign.enabled = false;
	}

	void Update () {
		if (myBowlingBall.transform.position.z > 60) {
			if (!isSignDisplay) {
				StartCoroutine (DelayAndDisplayText ());
			}
		}
	}

	IEnumerator DelayAndDisplayText () {
		yield return new WaitForSeconds (4.5f);
		myRestartSign.enabled = true;
		isSignDisplay = true;
	}
}
