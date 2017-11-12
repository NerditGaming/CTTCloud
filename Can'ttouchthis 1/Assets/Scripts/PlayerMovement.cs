using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController cc;
	public float moveSpeed;
	public float jumpForce;
	public float gravity;

	private Vector3 direction = Vector3.zero;


	// Use this for initialization
	void Start () {

		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		direction = (transform.forward * Input.GetAxis ("Vertical"))+(transform.right*Input.GetAxis("Horizontal"));
		direction = direction.normalized * moveSpeed;

		if (cc.isGrounded) {

			//direction = new Vector3 (Input.GetAxis ("Horizontal") * moveSpeed, 0, Input.GetAxis ("Vertical") * moveSpeed);

			//direction = transform.TransformDirection (direction);

			//direction = direction * moveSpeed;

			direction.y = 0f;

			if (Input.GetButtonDown ("Jump")) {
				direction.y = jumpForce;
			}

		}


		direction.y = direction.y + (Physics.gravity.y * gravity * Time.deltaTime);

		cc.Move (direction * Time.deltaTime);

	}
	
}
