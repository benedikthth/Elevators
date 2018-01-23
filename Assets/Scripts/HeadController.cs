using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour {

	public GameObject axe;
	SpriteRenderer sr;
	public float angle;

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir =  transform.position - axe.transform.position;

		angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;

		if (angle > 90 || angle < -90) {
			sr.flipY = true;
		} else {
			sr.flipY = false;
		}

		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}
}
