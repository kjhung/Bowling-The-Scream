using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	BallLauncher myBallLauncher;
	GameObject myAdjustSign;
	GameObject myArrowSign;
	GameObject myPowerBar;
	bool _isBallGo;
	int xAxisMoveRange = 5;
	float rotateAngleRange;

	void Start () {
		myBallLauncher = GameObject.Find ("BowlingBall").GetComponent<BallLauncher> ();
		myAdjustSign = GameObject.Find ("AdjustSign");
		myArrowSign = GameObject.Find ("ArrowSign");
		myPowerBar = GameObject.Find ("PowerBar");
	}

	void Update () {
		_isBallGo = myBallLauncher.isBallGo;


		// Keep rotation angle between -30deg to 30deg;
		rotateAngleRange = transform.localEulerAngles.y;
		if (rotateAngleRange > 180) {
			rotateAngleRange = rotateAngleRange - 360;
		}
		rotateAngleRange = Mathf.Clamp (rotateAngleRange, -30f, 30f);
		//-----

		if (!_isBallGo) {
			if (Input.GetKey (KeyCode.A)) {
				if (transform.position.x > -xAxisMoveRange) {
					transform.Translate (-5f * Time.deltaTime, 0, 0);
					myAdjustSign.transform.Translate (-5f * Time.deltaTime, 0, 0);
					myArrowSign.transform.Translate (-5f * Time.deltaTime, 0, 0);
					myPowerBar.transform.Translate (0, -5f * Time.deltaTime, 0);
				}
			}
			if (Input.GetKey (KeyCode.D)) {
				if (transform.position.x < xAxisMoveRange) {
					transform.Translate (5f * Time.deltaTime, 0, 0);
					myAdjustSign.transform.Translate (5f * Time.deltaTime, 0, 0);
					myArrowSign.transform.Translate (5f * Time.deltaTime, 0, 0);
					myPowerBar.transform.Translate (0, 5f * Time.deltaTime, 0);
				}
			}
			if (Input.GetKey (KeyCode.Q)) {
				if (rotateAngleRange > -30f) {
					transform.Rotate (0, -20f * Time.deltaTime, 0);
					myArrowSign.transform.Rotate (0, -20f * Time.deltaTime, 0);
				}
			}
			if (Input.GetKey (KeyCode.E)) {
				if (rotateAngleRange < 30f) {
					transform.Rotate (0, 20f * Time.deltaTime, 0);
					myArrowSign.transform.Rotate (0, 20f * Time.deltaTime, 0);
				}
			}
		}
	}
}