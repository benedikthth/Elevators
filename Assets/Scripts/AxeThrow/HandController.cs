using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HandController : MonoBehaviour {
	
	Rigidbody2D rigidbody;

	public Sprite hand_open;
	public Sprite hand_clenched;

	private bool hovering;
	private Collider2D currentPickupHover, currentPickup;

	public GameManager gameManager;

	public FixedJoint2D fixedJoint;

	PolygonCollider2D collider;

	private Vector2 trajectory;
	private Vector2 mousePosition;

	public SpriteRenderer spriteRenderer;

	public Vector2 dir;

	public float dee, dist;

	DistanceJoint2D distanceJoint;

	// Use this for initialization
	void Start () {

		hovering = false;
		currentPickupHover = null;


		rigidbody = GetComponent<Rigidbody2D> ();
		distanceJoint = GetComponent<DistanceJoint2D> ();
		trajectory = rigidbody.position - rigidbody.position;
		fixedJoint.enabled = false;

	}


	void OnTriggerEnter2D(Collider2D coll){

		if(coll.gameObject.tag.Equals("pickup") ){
			/*
			coll.gameObject.SendMessage ("grabEvent");
			fixedJoint.enabled = true;
			fixedJoint.connectedBody = coll.attachedRigidbody;
			*/
			currentPickupHover = coll;
			hovering = true;
		}

	}

	void OnTriggerExit2D(Collider2D coll){
		
		if (coll == currentPickupHover) {
			currentPickupHover = null;
			hovering = false;
		}
	}


	// Update is called once per frame
	void Update () {
		//if (Input.GetMouseButton (0)) {
			/*
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
			*/

			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
			 
			dee = Vector2.Distance (mousePosition, distanceJoint.connectedAnchor);

			dist = Vector2.Distance (mousePosition, distanceJoint.connectedAnchor);	

			dir = mousePosition - distanceJoint.connectedAnchor;

			if( dee <  distanceJoint.distance ){
				rigidbody.MovePosition (mousePosition);
			} else {
				dir.Normalize ();
				//rigidbody.velocity = dir;
				rigidbody.AddForce (dir * 1000); 
			}
		//}



		if(Input.GetMouseButton(0)){
			if (hovering) {
				currentPickup = currentPickupHover;
				fixedJoint.enabled = true;
				fixedJoint.connectedBody = currentPickupHover.attachedRigidbody;				

			}
			spriteRenderer.sprite = hand_clenched;

		}
			
		if ( Input.GetMouseButtonUp(0) ){
			spriteRenderer.sprite = hand_open;
			if (fixedJoint.enabled) {
				fixedJoint.enabled = false;
				currentPickup.gameObject.SendMessage ("releaseEvent");
				gameManager.SendMessage ("axeThrowEvent");
				currentPickup = null;
			}
		}

	}
}
