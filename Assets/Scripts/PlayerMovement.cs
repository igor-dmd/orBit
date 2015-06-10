using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float Speed = 0f;

	void Start () {
	}

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.D))
			transform.position += new Vector3 (Speed * Time.deltaTime, 0.0f, 0.0f);
		if (Input.GetKey (KeyCode.A))
			transform.position -= new Vector3 (Speed * Time.deltaTime, 0.0f, 0.0f);

	}
}
