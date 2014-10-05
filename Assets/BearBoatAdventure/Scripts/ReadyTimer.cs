using UnityEngine;
using System.Collections;

public class ReadyTimer : MonoBehaviour {
	public float timer = 0f;
	public GameObject readyButton;
	public Vector2 button_pos;
	public bool button_created = false;

	void buttonAppear(){
		button_pos = new Vector2 (0f, 0f);
		Instantiate (readyButton);
		button_created = true;
		}
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		timer = timer + Time.deltaTime;

		if (button_created == false && timer > 120f) {
			buttonAppear ();
				}
	
	}
}
