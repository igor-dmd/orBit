using UnityEngine;
using System.Collections;

public class PlayerMovement2 : MonoBehaviour {

	[HideInInspector]
	/// <summary>
	/// The facing right.
	/// </summary>
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	/// <summary>
	/// The jump.
	/// </summary>
	public bool jump = false;				// Condition for whether the player should jump.

	/// <summary>
	/// The move force.
	/// </summary>
	public float moveForce = 20f;			// Amount of force added to move the player left and right.
	/// <summary>
	/// The max speed.
	/// </summary>
	public float maxSpeed = 0.5f;				// The fastest the player can travel in the x axis.
	/// <summary>
	/// The jump force.
	/// </summary>
	public float jumpForce = 20f;			// Amount of force added when the player jumps.

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
	private float distToGround;


	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.1f);  

		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;
	}

	void FixedUpdate () {	

//		while (travel) {
//			transform.position = Vector2.MoveTowards(transform.position, pos, maxSpeed * Time.deltaTime);
//		}

		// Cache the horizontal input.
		float x = Input.GetAxis("Horizontal");

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat("Speed", Mathf.Abs(x));

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector2.right * maxSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(-Vector2.right * maxSpeed* Time.deltaTime);

		}

		// If the input is moving the player right and the player is facing left...
		if(x > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(x < 0 && facingRight)
			// ... flip the player.
			Flip();

		// If the player should jump...
		if(jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");
			
			// Add a vertical force to the player.
			GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
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

//
//	void Movement() {
//
//		if (Input.GetKey (KeyCode.D)) {
//			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
//			//Trigger para mudar a animacao quando o jogador estiver andando
//			animator.SetTrigger("PlayerWalking");
//
//		}
//		if (Input.GetKey (KeyCode.A)) {
//			transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
//			//Trigger para mudar a anima cao quando o jogador estiver andando
//			animator.SetTrigger("PlayerWalking");
//
//		}      
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			transform.Translate (Vector2.up * jumpSpeed * Time.deltaTime, Space.Self);
//			//Trigger para mudar a animacao quando o jogador estiver pulando
//			animator.SetTrigger("PlayerJumping");
//
//		}
//	}
}