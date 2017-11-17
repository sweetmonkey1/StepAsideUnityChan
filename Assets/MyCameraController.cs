using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {

	private GameObject unitychan;

	private float defference;

	// Use this for initialization
	void Start () {
		this.unitychan = GameObject.Find ("unitychan");

		this.defference = unitychan.transform.position.z - this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (0, this.transform.position.y, this.unitychan.transform.position.z - defference);
	}
}
