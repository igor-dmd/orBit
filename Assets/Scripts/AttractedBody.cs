using UnityEngine;
using System.Collections;

public class AttractedBody : MonoBehaviour {

	public AttractorBody attractor;
	private Transform myTransform;
	
	void Start () {
		GetComponent<Rigidbody2D> ().fixedAngle = false;

		myTransform = transform;
	}

	void FixedUpdate () {
		if (attractor) {
			attractor.Attract(myTransform);
		}
	}
}
