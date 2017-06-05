using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public BallLauncher myBallLauncher;
	GameObject myBowlingBall;
	bool _isBallGo;
	Vector3 cameraFollowOffset;
	Vector3 cameraAngleTo;
	float cameraFieldOfViewTo;
	bool isCameraFollowing;

	void Start () {
		myBowlingBall = GameObject.Find ("BowlingBall");
		myBallLauncher = myBowlingBall.GetComponent<BallLauncher> ();
		cameraFollowOffset = new Vector3 (-6.5f, 5.5f, -14f);
		cameraAngleTo = new Vector3 (15f, 22.5f, 0f);
		cameraFieldOfViewTo = 30;
		isCameraFollowing = false;
	}
	
	void Update () {
		_isBallGo = myBallLauncher.isBallGo;

		if (_isBallGo) {
			if (transform.position.z < 32.5) {
				StartCoroutine (CameraFollowWithDelay ());
			}
		}
//		Debug.Log (Camera.main.fieldOfView);
	}

	IEnumerator CameraFollowWithDelay () {
		if (!isCameraFollowing) {
			yield return new WaitForSeconds (.75f);
		}
		transform.position = myBowlingBall.transform.position + cameraFollowOffset; 
		transform.eulerAngles = Vector3.Lerp (transform.rotation.eulerAngles, cameraAngleTo, Time.deltaTime);
		Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, cameraFieldOfViewTo, Time.deltaTime);
		isCameraFollowing = true;
	}
}
