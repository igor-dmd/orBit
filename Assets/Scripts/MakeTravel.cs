using UnityEngine;
using System.Collections;

public class MakeTravel : MonoBehaviour {

	private GameObject player;
	private bool travel;
	private Animator anim;

	private Vector2 mousePos;

	void OnMouseDown() {
		player.GetComponent<PlayerMovement2> ().enabled = false;
		travel = true;
		mousePos = Input.mousePosition;
		//Debug.Log ("Down!");
		anim.SetBool ("Fly", true);
	}

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		anim = player.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D orbit) {
		player.GetComponent<PlayerMovement2> ().enabled = true;
		travel = false;
		anim.SetBool ("Fly", false);
	}

	void Update () {
		if (travel) {
			player.transform.position = Vector2.MoveTowards(new Vector2(player.transform.position.x, player.transform.position.y),
			                                                new Vector2(transform.position.x, transform.position.y), 2f * Time.deltaTime);
		}
	}
}
