using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

		private Rigidbody m_rb = null;
		private bool m_isStartedW = false;
		private bool m_isStartedS = false;
		private bool m_isStartedA = false;
		private bool m_isStartedD = false;
		private bool m_isStartedE = false;
		private bool m_isStartedQ = false;
		public Transform RainSpawn;
		public GameObject Rain;
		private float m_forceTime = 1.0f;
		static float m_Acc = 30.0f;
		static float mass = 1.0f;
		public static bool RainUsed = false;
		

		void Start () {
			m_rb = GetComponent<Rigidbody>();


		}

		// Update is called once per frame
		void Update ()
	{
		if (Input.GetKeyDown (KeyCode.P) && RainUsed == false) {
			RainUsed = true;
			Instantiate (Rain, RainSpawn);
		}


		if (Input.GetKeyDown (KeyCode.W)) {
			m_isStartedW = true;
		}		
		if (Input.GetKeyUp (KeyCode.W)) {
			m_isStartedW = false;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			m_isStartedS = true;
		}		
		if (Input.GetKeyUp (KeyCode.S)) {
			m_isStartedS = false;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			m_isStartedA = true;
		}		
		if (Input.GetKeyUp (KeyCode.A)) {
			m_isStartedA = false;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			m_isStartedD = true;
		}		
		if (Input.GetKeyUp (KeyCode.D)) {
			m_isStartedD = false;
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			m_isStartedQ = true;
		}		
		if (Input.GetKeyUp (KeyCode.Q)) {
			m_isStartedQ = false;
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			m_isStartedE = true;
		}		
		if (Input.GetKeyUp (KeyCode.E)) {
			m_isStartedE = false;
		}
		m_rb.mass = mass;
	}


		void FixedUpdate()
		{
			Vector3 up = transform.TransformDirection(Vector3.up);
			if (Input.GetKeyDown (KeyCode.Space) && this.transform.position.y <= 0.5f || Input.GetKeyDown (KeyCode.Space) && this.transform.position.x <= 177 && this.transform.position.y <= 3 && this.transform.position.x >= 175|| Input.GetKeyDown (KeyCode.Space) && this.transform.position.x >= 177 && this.transform.position.y <= 5)
			{
				m_rb.AddForce (up * 8, ForceMode.Impulse);
				Vector3 force = this.transform.forward * m_Acc;
				m_rb.AddForce(force);
			}
			if(m_isStartedW)
			{
				//apply force
				Vector3 force = this.transform.forward * m_Acc;
				m_rb.AddForce(force);

				m_forceTime -= Time.fixedDeltaTime;
			}
			if (m_isStartedS)
			{
				Vector3 force = this.transform.forward * -m_Acc;
				m_rb.AddForce (force);
			}
			if (m_isStartedA)
			{
				Vector3 force = this.transform.right * -m_Acc;
				m_rb.AddForce (force);
			}
			if (m_isStartedD)
			{
				Vector3 force = this.transform.right * m_Acc;
				m_rb.AddForce (force);
			}
			if (m_isStartedE)
			{
				this.transform.Rotate(Vector3.up * 3);

			}
			if (m_isStartedQ)
			{
				this.transform.Rotate(Vector3.up * -3);

			}

		}

	}