using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartControl : MonoBehaviour {

	static GameObject myBGM;
	AudioSource myBGMSource;
	bool audioBegin = false; 

	void Awake () {

		if (myBGM == null) {
			myBGM = GameObject.Find ("BGM");
			DontDestroyOnLoad (this.gameObject);

			if (!audioBegin) {
				myBGMSource = this.GetComponent <AudioSource> ();
				myBGMSource.Play ();
				audioBegin = true;
			}
		} else {
			Destroy (this.gameObject);
			return;
		}
	}

	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
	}
}
