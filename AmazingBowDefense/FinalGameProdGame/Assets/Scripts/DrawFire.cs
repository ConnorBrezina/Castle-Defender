using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFire : MonoBehaviour {

	private int MaxPower = 100;
	public float CurrentPower = 0.0f;
	private int MinPower = 0;
	private Rigidbody m_rb = null;

	public int ArrowSpeed = -100;

	public GameObject[] Arrows;

	// Use this for initialization
	void Start () {
		GameObject[] Arrows = new GameObject[3];
	}
	
	// Update is called once per frame
	void Update () {
		m_rb = Arrows[0].GetComponent<Rigidbody>();

		if (!Input.GetMouseButton (1)) {
			Arrows [0].transform.position = new Vector3 (Arrows [1].transform.position.x, Arrows [1].transform.position.y, Arrows [1].transform.position.z);
		}
		if (Input.GetMouseButton (1) && CurrentPower < MaxPower) 
		{
			CurrentPower++;
			//Vector3 force = Arrows[0].transform.up * CurrentPower * 0.01f;
			Arrows [0].transform.position = new Vector3 (Arrows [1].transform.position.x, Arrows [1].transform.position.y, Arrows[1].transform.position.z - 0.01f * CurrentPower);
			//Vector3 force = Arrows[0].transform.up * CurrentPower * 0.001f;
			//m_rb.AddForce(force);
			Debug.Log (CurrentPower);
		}
		if (CurrentPower == 99) {
			Vector3 MaxDraw = Arrows [0].transform.position;
		}
		if(Input.GetMouseButton (1) && CurrentPower == MaxPower)
		{
			
			Arrows [0].transform.position = new Vector3 (Arrows [1].transform.position.x, Arrows [1].transform.position.y, Arrows[1].transform.position.z - 0.005f * CurrentPower);
		}
		if (!Input.GetMouseButton (1) && CurrentPower > MinPower) 
		{
			Fire ();
			CurrentPower = 0;
			Debug.Log (CurrentPower);
		}
	}

	void Fire()
	{
		//Arrows [0].transform.position = new Vector3 (Arrows [1].transform.position.x, Arrows [1].transform.position.y, CurrentPower * 0.05f + Arrows [1].transform.position.z);
		Vector3 force = Arrows[0].transform.up * CurrentPower * ArrowSpeed *Time.deltaTime;
		m_rb.AddForce(force);
		//m_rb.AddTorque(Arrows[0].transform.right);
		m_rb.useGravity = true;
		Arrows [0].transform.parent = null;
		Arrows [0] = null;
		Arrows [0] = (Instantiate(Arrows[4], Arrows[3].transform.position, Arrows[3].transform.rotation) as GameObject).gameObject;
		Arrows [0].transform.parent = Arrows [2].transform;
		 

	}

}
