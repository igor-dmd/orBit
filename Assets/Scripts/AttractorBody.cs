using UnityEngine;
using System.Collections;

public class AttractorBody : MonoBehaviour {
	
	public float gravity = -12;

	public void Attract(Transform body) {
		Vector2 gravityUp = (body.position - transform.position).normalized;
		Vector2 localUp = body.up;

		body.GetComponent<Rigidbody2D>().AddForce (gravityUp * gravity);

		Quaternion targetRotation = Quaternion.FromToRotation(localUp,gravityUp) * body.rotation;
		body.rotation = Quaternion.Slerp(body.rotation,targetRotation,50f * Time.deltaTime );
	}

}
