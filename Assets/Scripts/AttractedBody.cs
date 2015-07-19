using UnityEngine;
using System.Collections;

public class AttractedBody : MonoBehaviour {

	public AttractorBody attractor;

	void Start () {
		GetComponent<Rigidbody2D> ().freezeRotation = true;
	}

	void OnTriggerEnter2D(Collider2D orbit) {
		attractor = orbit.gameObject.GetComponent<AttractorBody> ();
	}
	void OnTriggerExit2D(Collider2D orbit) {
		attractor = null;
	}

	void FixedUpdate () {

		if (attractor) {
			attractor.Attract(transform);
		}
	}

	void LateUpdate() {
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}
}
