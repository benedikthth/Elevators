using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

	public void AxeThrowScene(){
		SceneManager.LoadScene("Main");
	}

	public void MissileBlockScene(){
		SceneManager.LoadScene("MissileGame");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
