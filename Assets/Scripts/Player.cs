using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

		private Animator animator;
		private CharacterController controller;

	[SerializeField] float speed = 600.0f;
	[SerializeField] float turnSpeed = 400.0f;
	[SerializeField] float jumpSpeed = 8.0f;

	public Vector3 moveDirection = Vector3.zero;

	[SerializeField] float gravity = 20.0f;

	public int health;
		void Start () {
			controller = GetComponent <CharacterController>();
			animator = gameObject.GetComponentInChildren<Animator>();

		health = 200;
		}

		void Update (){


		//Taken from the astronaut assets pack on the unity store. https://assetstore.unity.com/packages/3d/characters/humanoids/sci-fi/stylized-astronaut-114298
		//Borrowed but also edited it to fit with what we learned in class from the character controller tutorial professor Gilbert gave. 
		
			

			float turnX = Input.GetAxis("Horizontal");
			float turnY = Input.GetAxis("Vertical");
		if (turnX != 0 || turnY != 0)
			{
				animator.SetInteger("AnimationPar", 1);
			}
			else
			{
				animator.SetInteger("AnimationPar", 0);
			}

			

		//]
		int platformLayer = LayerMask.GetMask("PlatformCar");

		//bool RaycastTouch = Physics.Raycast(transform.position, Vector3.down * 0.01f, jumpSpeed, platformLayer);

		if (controller.isGrounded)
		{
			moveDirection = transform.forward * turnY * speed;


			if (Input.GetKey(KeyCode.Space))
			{
				moveDirection.y = Mathf.Lerp(moveDirection.y, jumpSpeed, jumpSpeed/2);

			}
		}

		transform.Rotate(0, turnX * turnSpeed * Time.deltaTime, 0);
		moveDirection.y -= gravity * Time.deltaTime * speed;

		controller.Move(moveDirection * Time.deltaTime * speed);


		if(health <= 0)
        {
			SceneManager.LoadScene("Game");
        }



		int taxiLayer = LayerMask.GetMask("PlatformTaxi");

		bool RaycastBounce = Physics.Raycast(transform.position, Vector3.down, 1f, taxiLayer);

		Debug.Log(RaycastBounce);
		if (RaycastBounce)
		{
			moveDirection.y = 15f;
			moveDirection.x += 0.1f;
		}
	}
}
