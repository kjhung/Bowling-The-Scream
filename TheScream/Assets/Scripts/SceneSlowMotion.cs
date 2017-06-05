using UnityEngine;
using System.Collections;

public class SceneSlowMotion : MonoBehaviour {

	GameObject myBowlingBall;

	float slowMoTimeScale;
	float scaleSize = 3f;
	float slowMoStart = 20f;
	float slowMoEnd = 50f;

	void Start () {
		slowMoTimeScale = Time.timeScale / scaleSize;
		myBowlingBall = GameObject.Find ("BowlingBall");
	}

	void Update () {
		if (myBowlingBall.transform.position.z > slowMoStart && myBowlingBall.transform.position.z < slowMoEnd) {
			Time.timeScale = slowMoTimeScale;
			//Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
		} else {
			Time.timeScale = 1f;
		}
	}

}
