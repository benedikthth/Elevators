using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AxeController : MonoBehaviour {

	public GameObject COM;
	Rigidbody2D rigidbody;
	public GameManager gameManager;


	public AudioSource ac;
	public AudioClip axeLandSound;


	private bool thrown = false;

	public PolygonCollider2D axeHeadCollider, shaftCollider;

	// Use this for initialization
	void Start () {
		rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		rigidbody.centerOfMass = COM.transform.localPosition;

		if (axeHeadCollider == null || shaftCollider == null) {
			Debug.Log ("AxeController.cs: either axehead or shaft collider not set");
		}

	}




	void OnTriggerEnter2D(Collider2D coll){
		
		if (coll.IsTouching (axeHeadCollider)) {
			
			if(coll.gameObject.tag.Equals("collidible") || coll.gameObject.tag.Equals("ground") ){
				Debug.Log ("axehead is collided");

				ac.clip = axeLandSound;
				ac.Play();

				rigidbody.gravityScale = 0;
				rigidbody.velocity = Vector2.zero;
				rigidbody.angularVelocity = 0;
				if (!coll.gameObject.name.Equals ("StartingPillar") && !coll.gameObject.tag.Equals("target") ) {
					gameManager.SendMessage ("axeLandEvent");
				}

				if(coll.gameObject.name.Equals("target")){
					gameManager.SendMessage("targetHitEvent");

				}

			}
		
		} else {
			Debug.Log ("axeshaft is collided");
			if(coll.gameObject.tag.Equals("ground") ){
				gameManager.SendMessage ("axeLandEvent");
			} else if (coll.gameObject.name.Equals("blocker") ){
				Debug.Log("sasdas");
				coll.gameObject.SetActive(false);
			}
		}

	}



	void releaseEvent(){
		Debug.Log ("Axe is released");
		thrown = true;
		rigidbody.gravityScale = 1.0f;
	}

	// Update is called once per frame
	void Update () {
		
		if (rigidbody.velocity.magnitude <= 1 && thrown) {
			gameManager.SendMessage ("axeLandEvent");
		}


	}




}
