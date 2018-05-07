using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager1 : MonoBehaviour {

	public Text[] texts;
	public Button[] buttons;
	public Slider HP;

	public int playerDmg = 10;
	public int PowerUpRate = 20;
	public static int gold = 100;
	public int EnemiesLeft = 2;
	public GameObject SP;
	public static int MaxWallHp = 100;
	public static int WallCurrHp = 100;
	public static int Level = 1;
	private static int DR = 1;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this.gameObject);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Scene scene = SceneManager.GetActiveScene ();
		Debug.Log("Window width: " + Screen.width);
		Debug.Log("Window h: " + Screen.height);
		if (WallCurrHp <= 0) {
			texts [2].text = "You Lose";
			HP.value = 0;
		}
		if (Input.GetKeyUp (KeyCode.Z)) {
			gold += 100;
			SceneManager.LoadScene ("Shop");
		}
		if (scene.name == "Level" && WallCurrHp > 0) {
			texts [0] = GameObject.Find ("Gold").GetComponent<Text>();

			texts [1] = GameObject.Find ("EnemiesLeft").GetComponent<Text>();
			texts [0].text = "Gold: " + gold;
			texts [1].text = "Enemys Reinforcements: " + EnemiesLeft;
			texts [2] = GameObject.Find ("WallHp").GetComponent<Text>();
			texts [2].text = WallCurrHp + "/" + MaxWallHp;
			HP = GameObject.Find ("WallHealth").GetComponent<Slider> ();
			HP.maxValue = MaxWallHp;
			HP.value = WallCurrHp;

		}

		if (scene.name == "Shop") {
			texts [0] = GameObject.Find ("Gold").GetComponent<Text>();
			texts [3] = GameObject.Find ("WallHp").GetComponent<Text>();
			texts [0].text = "Gold: " + gold;
			texts [3].text = "Wall: " + WallCurrHp + "/" + MaxWallHp;
			buttons [0] = GameObject.Find ("RepairB").GetComponent<Button>();
			buttons [1] = GameObject.Find ("UpgradesB").GetComponent<Button>();
			buttons [2] = GameObject.Find ("NextLVB").GetComponent<Button>();
		}

		if (EnemiesLeft <= 0 && scene.name == "Level") {
			SP = GameObject.FindGameObjectWithTag("SP");
			EnemySpawn SPi = SP.GetComponent<EnemySpawn> ();
			SPi.Spawning = false;
		}
		if (EnemiesLeft > 0 && scene.name == "Level") {
			SP = GameObject.FindGameObjectWithTag("SP");
			EnemySpawn SPi = SP.GetComponent<EnemySpawn> ();
			SPi.Spawning = true;
		}
	}
	public void IncWallHp()
	{
		MaxWallHp += 20;
		WallCurrHp += 20;
	}
	public static void WallDmg(int D)
	{
		WallCurrHp -= D - (DR-1);
	}
	public static void EndLv()
	{
		SceneManager.LoadScene ("Shop");
	}
	public void StartLv()
	{
		Level++;
		SceneManager.LoadScene ("Level");
		PlayerController.RainUsed = false;
	}
	public void UpgradeWall()
	{
		if (gold > 20 * DR) {
			gold -= 20 * DR;
			DR++;
			IncWallHp ();
		}
	}
	public void RepairWall()
	{
		if (gold > (2* (MaxWallHp - WallCurrHp)))
		{
			gold -= (2 * (MaxWallHp - WallCurrHp));
			WallCurrHp = MaxWallHp;
		}
	}
	public void StartGame()
	{
		SceneManager.LoadScene ("Level");
	}
}
