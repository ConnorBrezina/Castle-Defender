using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	private GameObject go;
	private static int EnemiesLeft;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Enemy")
		{
			Enemy go = other.GetComponent<Enemy> ();
			this.transform.parent = go.transform;
			rb = this.GetComponent<Rigidbody>();
			rb.velocity = new Vector3 (0, 0, 0);
			rb.useGravity = false;
			go.Hp -= 50;
		}

	}
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Enemy")
		{
			Enemy go = other.GetComponent<Enemy> ();
			go.Hp -= 50;
			//DestroyObject(other.gameObject);
			Destroy (this.gameObject);

		}

	}
}
