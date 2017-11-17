using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "CoinTag" || other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag") {
			Destroy (other.gameObject);
		}
	}
}
