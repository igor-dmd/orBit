using UnityEngine;
using System.Collections;

public class MakeTravel : MonoBehaviour {

	private GameObject player;
	private bool travel;
	private bool onSpace;
	private Animator anim;

	private Collider2D currentOrbit; //Radius for testing if the player is inside the bounds of the orbit

	private Collider2D[] colliders;

	private Vector2 mousePos;

	void OnMouseDown() {

		colliders = GetComponents<CircleCollider2D>();
		foreach (CircleCollider2D collider in colliders) {
			if (collider.isTrigger) {
				currentOrbit = collider;
			}
		}

		if (currentOrbit.bounds.Contains(player.transform.position)) {
				travel = false;
		} else {
			travel = true;
			player.GetComponent<PlayerMovement2> ().enabled = false;
			anim.SetBool ("Fly", true);
		}
	}

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");

		anim = player.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D orbit) {

		//Get current orbit
		currentOrbit = orbit;
	
		player.GetComponent<PlayerMovement2> ().enabled = true;
		travel = false;
		anim.SetBool ("Fly", false);
	}

	void OnTriggerExit2D(Collider2D orbit) {
		onSpace = true;
	}

	void Update () {
		if (travel) {
			player.transform.position = Vector2.MoveTowards(new Vector2(player.transform.position.x, player.transform.position.y),
			                                                new Vector2(transform.position.x, transform.position.y), 2f * Time.deltaTime);
		}
	}
}
