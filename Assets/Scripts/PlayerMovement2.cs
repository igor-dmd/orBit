using UnityEngine;
using System.Collections;

public class PlayerMovement2 : MonoBehaviour {
	
	void Update() {
		Movement ();
	}

	void Movement() {
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(-Vector2.right * 4f * Time.deltaTime);
		}      
	}
}