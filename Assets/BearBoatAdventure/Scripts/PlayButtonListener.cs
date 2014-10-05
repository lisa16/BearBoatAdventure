using UnityEngine;
using System.Collections;

public class PlayButtonListener : MonoBehaviour {

	[SerializeField]
	private GameObject _sceneFadeOut;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Instantiate (_sceneFadeOut);
		}
}
