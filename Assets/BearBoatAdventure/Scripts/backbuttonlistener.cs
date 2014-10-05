using UnityEngine;
using System.Collections;

public class backbuttonlistener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		// this object was clicked - do something
		Application.LoadLevel("Instructions1");
	}  
}
