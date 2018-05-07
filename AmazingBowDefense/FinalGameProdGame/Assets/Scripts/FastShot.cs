using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastShot : MonoBehaviour {

	public RawImage[] image;
	private GameObject player;
	// Use this for initialization
	void Start () {
		image[0].color = new Color (image[0].color.r, image[0].color.g, image[0].color.b, 0);
		image[1].color = new Color (image[1].color.r, image[1].color.g, image[1].color.b, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		image[0].color = new Color (image[0].color.r, image[0].color.g, image[0].color.b, 1);
		image[1].color = new Color (image[1].color.r, image[1].color.g, image[1].color.b, 1);
		this.transform.position = new Vector3 (1000 ,0 , 0);
		StartCoroutine (End ());
		DrawFire player = GameObject.Find ("Player").GetComponent<DrawFire>();
		player.CurrentPower = 100;
	}

	IEnumerator End()
	{
		DrawFire player = GameObject.Find ("Player").GetComponent<DrawFire>();
		yield return new WaitForSeconds (1f);
		player.CurrentPower = 100;
		yield return new WaitForSeconds (1f);
		player.CurrentPower = 100;
		yield return new WaitForSeconds (1f);
		player.CurrentPower = 100;
		yield return new WaitForSeconds (1f);
		player.CurrentPower = 100;
		yield return new WaitForSeconds (1f);
		player.CurrentPower = 100;
		yield return new WaitForSeconds (1f);
		player.CurrentPower = 100;
		yield return new WaitForSeconds (2f);
		image[0].color = new Color (image[0].color.r, image[0].color.g, image[0].color.b, 0);
		image[1].color = new Color (image[1].color.r, image[1].color.g, image[1].color.b, 0);
		Destroy (this.gameObject);
	}
}
