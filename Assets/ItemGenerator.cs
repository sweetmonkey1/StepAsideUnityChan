using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	public GameObject carPrefab;
	public GameObject coinPrefab;
	public GameObject conePrefab;

	private int startPos = -160;

	private float posRange = 3.4f;
	private GameObject unitychanObject ;
	private float unitychanPos;
	private float intervalTime = 0.5f;
	private float timeCounter = 0f;

	// Use this for initialization
	void Start () {
		this.unitychanObject = GameObject.Find ("unitychan");
		unitychanPos = unitychanObject.transform.position.z;
		for (int i = startPos; i < startPos + 40; i +=10) {
			int num = Random.Range (0, 10);
			if (num <= 1) {
				for(float j = -1; j <= 1; j+= 0.4f){
					GameObject cone = Instantiate(conePrefab) as GameObject;
					cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
				}
			}else{
				for(int j = -1; j < 2; j++){
					int item = Random.Range(1,11);
					int offsetZ = Random.Range(-5,6);
					if(1 <= item && item <= 6){
						GameObject coin = Instantiate(coinPrefab) as GameObject;
						coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
					}else if(7 <= item && item <= 9){
						GameObject car = Instantiate(carPrefab) as GameObject;
						car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		if (timeCounter >= intervalTime) {
			timeCounter = 0;
			ItemCreate ();
		}
	}

	void ItemCreate(){
		float zPos = unitychanObject.transform.position.z + 40;
		int num = Random.Range (0, 10);
		if (num <= 1) {
			for(float i = -1; i <= 1; i+= 0.4f){
				GameObject cone = Instantiate(conePrefab) as GameObject;
				cone.transform.position = new Vector3(4 * i, cone.transform.position.y, zPos);
			}
		}else{
			for(int j = -1; j < 2; j++){
				int item = Random.Range(1,11);
				if(1 <= item && item <= 6){
					GameObject coin = Instantiate(coinPrefab) as GameObject;
					coin.transform.position = new Vector3(posRange * j, coin.transform.position.y,zPos);
				}else if(7 <= item && item <= 9){
					GameObject car = Instantiate(carPrefab) as GameObject;
					car.transform.position = new Vector3(posRange * j, car.transform.position.y, zPos);
				}
			}
		}
	}
}
