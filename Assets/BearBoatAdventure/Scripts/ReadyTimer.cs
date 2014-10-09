using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadyTimer : MonoBehaviour {
	private float timer = 0f;
	public GameObject readyButton;
	private Vector2 button_pos;
	private bool button_created = false;

	[SerializeField]
	private string _readyInTimerText;

	Text timerText;

	[SerializeField]
	private int buttonAppearTime;

	void buttonAppear(){
		button_pos = new Vector2 (0f, 0f);
		Instantiate (readyButton);
		button_created = true;
		}
	// Use this for initialization
	void Start () {
		timerText = this.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		timer = timer + Time.deltaTime;

		if (button_created == false && timer > buttonAppearTime) {
			buttonAppear ();
		}

		if(button_created)
		{
			timerText.text = string.Empty;
		}
		else
		{
			string secondsText = (buttonAppearTime-timer).ToString("#");
			timerText.text = string.Format(_readyInTimerText, secondsText);
		}
	}
}
