using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float rotatespeed;
	public Transform pivot;

	// Use this for initialization
	void Start () {
		offset = target.position - transform.position;
		pivot.transform.position = target.transform.position;
		pivot.transform.parent = target.transform;

		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		float horizontal = Input.GetAxis ("Mouse X") * rotatespeed;
		target.Rotate (0, horizontal,0);

		float vertical = Input.GetAxis ("Mouse Y") * rotatespeed;
		pivot.Rotate (vertical, 0, 0);

		float angulo_y = target.eulerAngles.y;
		float angulo_x = pivot.eulerAngles.x;
		Quaternion rotation = Quaternion.Euler (-angulo_x, angulo_y, 0);

		transform.position = target.position - (rotation * offset);

		//transform.position = target.position - offset;

		transform.LookAt (target);
	}
}
