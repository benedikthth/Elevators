using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

	public GameObject explosion;
	public float missileSpeed;
	public float dither;

	public AudioClip explosionSound, batCollisionSound;

	public AudioSource ac;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2(missileSpeed, missileSpeed));
	}

	
	public void Explode(){
		GameObject doop = GameObject.Instantiate(explosion);
		doop.transform.position = transform.position;
		Destroy(doop, 1);
		
		ac.clip = explosionSound;
		ac.Play();
		
		//ac.PlayOneShot();
		//explosionSound.Play();
	}

	void OnCollisionEnter2D(Collision2D coll){
		Debug.Log("MissileCollision");
		ac.clip = batCollisionSound;
		ac.Play();
	}

	// Update is called once per frame
	void Update () {




		if(transform.position.y >= 50 || transform.position.y <= -16){
			Destroy(gameObject);
		}


		//transform.rotation.SetEulerAngles(rb.velocity);

		/* 	
		Vector3 newPos = transform.position;
		newPos.x += missileSpeed * Time.deltaTime;
		transform.position = newPos;
		*/
	}
}
