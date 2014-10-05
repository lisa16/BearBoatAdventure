using UnityEngine;
using System.Collections;

public class readybuttonlistener : MonoBehaviour {
	[SerializeField]
	private GameObject _sceneFadeOut;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){
		// this object was clicked - do something
		Instantiate (_sceneFadeOut);
	}  
}
