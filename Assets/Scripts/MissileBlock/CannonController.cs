using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

	public GameObject missile; 

	public float missileDelay;
	float _time;
	public float minY, maxY;

	public float cannonSpeed;

	public float nextPos;
	private int direction = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		_time += Time.deltaTime;
		if(_time > missileDelay){
			_time = 0;
			shoot();
		}


		nextPos = gameObject.transform.position.y + direction * cannonSpeed * Time.deltaTime;

		Vector3 pos = gameObject.transform.position;

		if(nextPos  >= maxY){
			pos.y = maxY;
			direction *= -1;
		} else if(nextPos <= minY){
			pos.y = minY;
			direction *= -1;
		} else {

				pos.y += cannonSpeed * direction * Time.deltaTime;

		}

		
	gameObject.transform.position = pos;		

	}

	public void shoot(){
		GameObject newmissile = Instantiate(missile, transform.position, Quaternion.identity);
	}
}
