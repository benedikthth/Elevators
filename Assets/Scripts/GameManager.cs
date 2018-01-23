using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public GameObject tryAgainButton;

	public Camera mainCamera;
	public GameObject axe;
	public Rigidbody2D axebody;
	public float originalOrtographicSize;
	public float vel;

	public GameObject ground;
	public Sprite groundSprite;

	public float zoom = 0;

	private bool thrown;

	void axeThrowEvent(){
		thrown = true;
	}

	void tryAgain(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	void axeLandEvent(){
		thrown = false;
		tryAgainButton.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		originalOrtographicSize = mainCamera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {


		zoom -= Input.mouseScrollDelta.y;


		float groundOffset = mainCamera.transform.position.x % groundSprite.bounds.size.x; 

		ground.transform.position = new Vector3 (
											     mainCamera.transform.position.x - groundOffset,
												 ground.transform.position.y,
												 ground.transform.position.z
												);
		float axeModifier = 0;
		if (thrown) {

			vel = axebody.velocity.magnitude;
			mainCamera.transform.position = axe.transform.position + new Vector3 (0, 0, -10);
			axeModifier = (3 * axebody.velocity.magnitude * .2f);
		}

		mainCamera.orthographicSize = originalOrtographicSize + zoom + axeModifier;
	
	}
}
