using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public GameObject tryAgainButton;
	public GameObject winMessage;
	public Camera mainCamera;
	public GameObject axe;
	public GameObject COW;
	public Rigidbody2D axebody;
	public float originalOrtographicSize;
	public float vel;

	public GameObject exitMenu;

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
		exitMenu.SetActive(false);	

	}
	
	void targetHitEvent(){

		thrown = false;
		winMessage.SetActive (true);

	}

	public void MainMenu(){
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)){
			Time.timeScale = (!	exitMenu.activeSelf)? 0 : 1	;
			exitMenu.SetActive( !exitMenu.activeSelf );
		}

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
			mainCamera.transform.position = COW.transform.position + new Vector3 (0, 0, -10);
			axeModifier = (3 * axebody.velocity.magnitude * .2f);
		}

		mainCamera.orthographicSize = originalOrtographicSize + zoom + axeModifier;
	
	}
}
