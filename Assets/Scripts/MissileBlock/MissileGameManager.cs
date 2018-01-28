using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissileGameManager : MonoBehaviour {

	public Collider2D playerSideCollider, cannonSideCollider;

	public Text playerScoreDisplay, cannonScoreDisplay;

	public GameObject exitMenu;

	int playerScore, cannonScore;

	// Use this for initialization
	void Start () {
		cannonScore = 10;
		playerScore = 10;
		exitMenu.SetActive(false);
	}
	
	public void MainMenu(){
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}

	public void OnTriggerEnter2D	(Collider2D coll){

		Debug.Log(coll.name);

		if(coll.tag == "Missile"){
			if(coll.IsTouching(playerSideCollider)){
				playerScore --;
			} else {
				cannonScore --;
			}
			coll.gameObject.SendMessage("Explode");
		}
	}

	public void WaitAndDestroy(){
		/* 
		yield WaitForSeconds(delay);
		Destroy (gameObject);
		 */
 	}




	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)){
			Time.timeScale = (!	exitMenu.activeSelf)? 0 : 1	;
			exitMenu.SetActive( !exitMenu.activeSelf );
		}

		playerScoreDisplay.text = playerScore.ToString();
		cannonScoreDisplay.text = cannonScore.ToString();
		if(playerScore == 0 || cannonScore == 0){
			SceneManager.LoadScene("MainMenu");
		}
	}
}
