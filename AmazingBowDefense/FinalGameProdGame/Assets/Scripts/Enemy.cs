using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject[] SpawnAttack;
	public bool Attacking = false;
	private Animator Attack;
	private bool dmgTime = false;
	private Vector3 MovePos;
	public int Hp = 10;

	// Use this for initialization
	void Awake()
	{
		Hp += 90 + (10 * GameManager1.Level);
		SpawnAttack [1] = GameObject.FindGameObjectWithTag("Gate");
		MovePos = new Vector3 (SpawnAttack[1].transform.position.x + (Random.Range(-15,15)), SpawnAttack[1].transform.position.y, SpawnAttack[1].transform.position.z);
		Attack = this.GetComponent<Animator>();
	}
	void Start () {
		InvokeRepeating ("Damaging", 2.5f, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(this.transform.position, MovePos, 0.2f);
		if (this.transform.position == MovePos) {
			Attack.SetBool ("Attacking", true);
			dmgTime = true;
		}
		if (Hp <= 0) {
			Destroy (this.gameObject);
			EnemySpawn.EnLeftToKill--;
			GameManager1.gold += 10;
		}
	}
	void Damaging()
	{
		if (dmgTime == true) {
			GameManager1.WallDmg (10);
		}
	}
}
