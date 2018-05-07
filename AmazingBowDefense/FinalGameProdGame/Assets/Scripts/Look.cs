using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Look : MonoBehaviour {

	//public Camera camera;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame

	void Update() {
		if (Input.GetMouseButton (0))
			RotateToMouse ();
	}
	void RotateToMouse() {
		//transform.LookAt (Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)), Vector3.up);
	
		float xRot = Camera.main.transform.eulerAngles.x + Input.GetAxis ("Mouse Y") * 8.0f *-1.0f;
		if (xRot < 310 && xRot > 150.0f)
			xRot = 310.0f;
		if (xRot > 50.0f && xRot < 150.0f)
			xRot = 50.0f;
		Vector3 newLook = new Vector3 (xRot, Camera.main.transform.eulerAngles.y + Input.GetAxis ("Mouse X") * 12.0f, 0);
		//Camera.main.transform.rotation = Quaternion.Euler (newLook);


		transform.eulerAngles = newLook;
	}
}
