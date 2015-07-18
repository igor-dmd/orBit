using UnityEngine;
using System.Collections;

public class PlayerMovement2 : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.

	[HideInInspector]
	public float maxSpeed = 0.5f;				// The fastest the player can travel in the x axis.

	private Animator anim;					// Reference to the player's animator component.

	void Awake()
	{
		// Setting up references.;
		anim = GetComponent<Animator>();
	}


	void FixedUpdate () {

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector2.right * maxSpeed * Time.deltaTime);

			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetFloat ("Speed", Mathf.Abs (maxSpeed));
		} else if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-Vector2.right * maxSpeed * Time.deltaTime);

			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetFloat ("Speed", Mathf.Abs (maxSpeed));
		} 

		else {
			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetFloat ("Speed", Mathf.Abs (0));
		}

		// If the input is moving the player right and the player is facing left...
		if(Input.GetKey(KeyCode.D) && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(Input.GetKey(KeyCode.A) && facingRight)
			// ... flip the player.
			Flip();

	}



	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}