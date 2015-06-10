using UnityEngine;
using System.Collections;

public class PlayerMovement2 : MonoBehaviour {

	public float speed = 0f;

	void Update() {
		Movement ();
	}

	void Movement() {
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(-Vector2.right * speed * Time.deltaTime);
		}      
	}
}