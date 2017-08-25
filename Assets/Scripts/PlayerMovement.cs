using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
	public GameObject klb;
	Vector3 oldPos;
	Vector3 newPos;
	public GameManager gm;
	private float health = 3;

	// Use this for initialization
	void Start () {
		oldPos = new Vector3 (transform.position.x,transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		gm.WriteHpText (health);
		if (klb) {
			newPos = new Vector3 (klb.transform.position.x - oldPos.x, klb.transform.position.y - oldPos.y, 0);
			transform.position = oldPos + newPos * 5;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Obstacle") {
			Debug.Log ("HIT");
			if (health - other.GetComponent<ObstacleMovement> ().GetHealth () <= 0)
				SceneManager.LoadScene ("GemLevel1");
			else {
				health -= other.GetComponent<ObstacleMovement> ().GetHealth ();
			}
		}
		if (other.gameObject.tag == "Collectable") {
			//score++;
			gm.UpScore(other.GetComponent<ObstacleMovement>());
			Destroy (other.gameObject);
		}
	}


}
