using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private Animator animator;
		private CharacterController controller;

	[SerializeField] float speed = 600.0f;
	[SerializeField] float turnSpeed = 400.0f;
	[SerializeField] float jumpSpeed = 8.0f;

	private Vector3 moveDirection = Vector3.zero;

	[SerializeField] float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			animator = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){


		//Taken from the astronaut assets pack on the unity store. https://assetstore.unity.com/packages/3d/characters/humanoids/sci-fi/stylized-astronaut-114298
		//Borrowed but also edited it to fit with what we learned in class from the character controller tutorial professor Gilbert gave. 
		moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
			

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

			transform.Rotate(0, turnX * turnSpeed * Time.deltaTime, 0);
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);

		//]
		int platformLayer = LayerMask.GetMask("PlatformCar");

		bool RaycastTouch = Physics.Raycast(transform.position, Vector3.down * 0.01f, jumpSpeed, platformLayer);
		if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
			moveDirection.y += gravity;
			controller.Move(moveDirection * Time.deltaTime);
        }



	}
}
