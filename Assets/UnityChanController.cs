using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour {

	private Animator myAnimaor;
	private Rigidbody myRigidbody;
	//前進するための力
	private float forwardForce = 800.0f;
	private float turnForce = 500.0f;
	private float upForce = 500.0f;

	private float movaleRange = 3.4f;

	private float coefficient = 0.95f;

	private bool isEnd = false;
	private bool isLButtonDown = false;
	private bool isRButtonDown = false;

	private GameObject stateText;
	private GameObject scoreText;

	private int score = 0;

	// Use this for initialization
	void Start () {
		this.myAnimaor = GetComponent<Animator> ();

		this.myAnimaor.SetFloat ("Speed", 1.0f);

		this.myRigidbody = GetComponent<Rigidbody> ();

		this.stateText = GameObject.Find ("GameResultText");
		this.scoreText = GameObject.Find ("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {

		if (this.isEnd) {
			this.forwardForce *= coefficient;
			this.turnForce *= coefficient;
			this.upForce *= coefficient;
			this.myAnimaor.speed *= coefficient;
		}

		this.myRigidbody.AddForce (this.transform.forward * this.forwardForce);

		if (Input.GetKey (KeyCode.LeftArrow) && -this.movaleRange < this.transform.position.x || this.isLButtonDown && -this.movaleRange < this.transform.position.x) {
			this.myRigidbody.AddForce (-this.turnForce, 0, 0);
		} else if (Input.GetKey (KeyCode.RightArrow) && this.movaleRange > this.transform.position.x || this.isRButtonDown && this.movaleRange > this.transform.position.x) {
			this.myRigidbody.AddForce (this.turnForce, 0, 0);
		}

		if (this.myAnimaor.GetCurrentAnimatorStateInfo (0).IsName ("Jump")) {
			this.myAnimaor.SetBool ("Jump", false);
		}

		if (Input.GetKeyDown (KeyCode.Space) && this.transform.position.y < 0.5f) {
			this.myAnimaor.SetBool ("Jump", true);
			this.myRigidbody.AddForce (this.transform.up * this.upForce);
		}
			
	}
		void OnTriggerEnter(Collider other){
			if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag"){
				this.isEnd = true;
				
				this.stateText.GetComponent<Text> ().text = "GAME OVER";
			}

			if(other.gameObject.tag == "GoalTag"){
				this.isEnd = true;
				
				this.stateText.GetComponent<Text>().text = "CLEAR!!";
			}

			if (other.gameObject.tag == "CoinTag") {

				this.score += 10;

				this.scoreText.GetComponent<Text> ().text = "Score " + this.score + "Pt";

				GetComponent<ParticleSystem> ().Play ();	

				Destroy(other.gameObject);
			}
		}
	public void GetMyJumpButtonDown(){
		if (this.transform.position.y < 0.5f) {
			this.myAnimaor.SetBool ("Jump", true);
			this.myRigidbody.AddForce (this.transform.up * this.upForce);
		}
	}

	public void GetMyLeftButtonDown(){
		this.isLButtonDown = true;
	}
	public void GetMyLeftButtonUp(){
		this.isLButtonDown = false;
	}

	public void GetMyRightButtonDown(){
		this.isRButtonDown = true;
	}
	public void GetMyRightButtonUp(){
		this.isRButtonDown = false;
	}
}




