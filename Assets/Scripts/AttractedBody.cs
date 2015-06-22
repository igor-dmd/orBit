using UnityEngine;
using System.Collections;

public class AttractedBody : MonoBehaviour {

	public AttractorBody attractor;

	void Start () {
		GetComponent<Rigidbody2D> ().fixedAngle = false;
	}

	void OnTriggerEnter2D(Collider2D orbit) {
		attractor = orbit.gameObject.GetComponent<AttractorBody> ();
	}
	void OnTriggerExit2D(Collider2D orbit) {
		attractor = null;
	}

	void FixedUpdate () {

		if (attractor) {
//			Vector2 attractorPosition = attractor.gameObject.transform.position;
//			float planetRadius = attractor.gameObject.GetComponent<CircleCollider2D>().radius;
//
//			if (Vector2.Distance(transform.position, attractorPosition) < planetRadius * 2) {
//				attractor.Attract(transform);
//			}

			attractor.Attract(transform);
		}
	}

	void LateUpdate() {
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}
}
