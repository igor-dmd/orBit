using UnityEngine;
using System.Collections;

public class PlayerMovement2 : MonoBehaviour {

	public float moveSpeed = 0f;
	public float jumpSpeed = 10f;

	void Update() {
		Movement ();
	}

	void Movement() {
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
		}      

		if (Input.GetKeyDown (KeyCode.Space)) {
			transform.Translate (Vector2.up * jumpSpeed * Time.deltaTime, Space.Self);
		}
	}
}