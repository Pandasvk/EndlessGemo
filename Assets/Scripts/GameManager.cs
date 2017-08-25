using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject [] obstacles;
	public GameObject[] collectables;
	public float obstSpawnTimer =3;
	private float obstNextSpawnTime;
	public float collectSpawnTimer = 2;
	private float collectNextSpawnTime;
	private int collectCooldownTime=0;
	private float Score = 0;
	public Text ScoreText ;
	public Text NameText;
	public Text HealthText;


	// Use this for initialization

	void Start () {
		obstNextSpawnTime = Time.time + obstSpawnTimer;
		collectNextSpawnTime = Time.time + collectSpawnTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= obstNextSpawnTime) {
			ObstSpawn ();
			obstNextSpawnTime = Time.time + obstSpawnTimer;
		}
		if (Time.time >= collectNextSpawnTime) {
			CollectSpawn ();
			collectCooldownTime++;

			if (collectCooldownTime >= 10) {
				collectNextSpawnTime = Time.time + collectSpawnTimer + 8;
				collectCooldownTime = 0;
			} else {
				collectNextSpawnTime = Time.time + collectSpawnTimer;
			}
		}
	}

	void ObstSpawn(){
		int obstToSpawn = Random.Range (0, obstacles.Length);
		GameObject spawnedObst = Instantiate (obstacles [obstToSpawn]) as GameObject;
	}

	void CollectSpawn(){
		Vector3 pos;
		pos.x = Random.Range (0,14)-7;
		pos.y = -1.5f;
		pos.z = 125;
		int collToSpawn = Random.Range (0, collectables.Length);
		GameObject spawnedColl = Instantiate (collectables [collToSpawn], pos, transform.rotation) as GameObject;
	}

	public void UpScore(ObstacleMovement obsmove){
		Score += obsmove.GetPoints ();
		ScoreText.text = "Score : " + Score;
	}

	public void WriteHpText(float hp){
		HealthText.text = "HP : " + hp;
	}

}
