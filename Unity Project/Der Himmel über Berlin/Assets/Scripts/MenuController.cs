using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public GameObject StartScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //START
        if (Input.GetKey("space")){
            StartScreen.SetActive(false);
        }

        //QUIT
        if (Input.GetKey("escape"))
        {
            Debug.Log("You quit!");
            Application.Quit();
        }
    }
}
