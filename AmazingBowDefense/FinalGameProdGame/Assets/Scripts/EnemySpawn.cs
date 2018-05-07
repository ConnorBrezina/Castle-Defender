using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public GameObject[] Enemies;
	public int EnLeft = 4;
	public bool Spawning = true;
	public static int EnLeftToKill = 4;
	private Vector3 SpawnPos;
	private int RandomR;
	// Use this for initialization
	void Start () {
		SpawnPos = new Vector3 (this.transform.position.x + (Random.Range(-15,15)), this.transform.position.y, this.transform.position.z);
		if (GameManager1.Level >= 2 && GameManager1.Level < 5) {
			InvokeRepeating ("Spawn2", (7.0f-GameManager1.Level), (9.0f-GameManager1.Level));
		}
		if (GameManager1.Level >= 5 && GameManager1.Level < 10) {
			InvokeRepeating ("Spawn2", (8.0f-GameManager1.Level), (11.0f-GameManager1.Level));
		}
		EnLeft = 4 + (GameManager1.Level * GameManager1.Level) - (GameManager1.Level);
		EnLeftToKill = 4 + (GameManager1.Level * GameManager1.Level) - (GameManager1.Level);
		InvokeRepeating ("Spawn", 0.0f, 3.0f);
		GameManager1 gm1 = GameObject.Find ("GameManager").GetComponent<GameManager1>();
		gm1.EnemiesLeft = EnLeft;
	}
	
	// Update is called once per frame
	void Update () {
		SpawnPos = new Vector3 (this.transform.position.x + (Random.Range(-30,30)), this.transform.position.y, this.transform.position.z);
		if (EnLeftToKill <= 0) {
			if (EnLeft < 0){
				EnLeft = 0;
				GameManager1 gm1 = GameObject.Find ("GameManager").GetComponent<GameManager1> ();
				gm1.EnemiesLeft = EnLeft;
			}
			StartCoroutine (EndL ());
		}
	}
	void Spawn()
	{
		if (Spawning == true) {
			Instantiate (Enemies [0], SpawnPos, this.transform.rotation);
			EnLeft--;
			GameManager1 gm1 = GameObject.Find ("GameManager").GetComponent<GameManager1>();
			gm1.EnemiesLeft = EnLeft;
			//SpawnPos = new Vector3 (this.transform.position.x + (Random.Range(-15,15)), this.transform.position.y, this.transform.position.z);
		}
	}
	void Spawn2()
	{
		if (Spawning == true) {
			Instantiate (Enemies [1], SpawnPos, this.transform.rotation);
			EnLeft--;
			GameManager1 gm1 = GameObject.Find ("GameManager").GetComponent<GameManager1>();
			gm1.EnemiesLeft = EnLeft;
			//SpawnPos = new Vector3 (this.transform.position.x + (Random.Range(-15,15)), this.transform.position.y, this.transform.position.z);
		}
	}
	IEnumerator EndL()
	{
		yield return new WaitForSeconds (3);
		GameManager1.EndLv ();
	}
}
