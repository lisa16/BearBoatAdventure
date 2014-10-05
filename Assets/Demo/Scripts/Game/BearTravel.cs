using UnityEngine;
using System.Collections;
using BellaProject;
using Bindings;

public class BearTravel : MonoBehaviour {
	private int meters;
	public UnityEngine.UI.Text meterDisplay;
	public UnityEngine.UI.Text bannerDisplay;
	AudioSource goodAudio; 
	AudioSource strongAudio; 
	AudioSource weakAudio; 
//	public AudioClip Natchar;
//	float BannerX;


	void Start ()
	{
		meters = 0;
		meterDisplay.text = "Ready";
		bannerDisplay.text = "";
		Manager.messenger.Subscribe (BellaMessages.GoodBreath, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.WeakBreath, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.StrongBreath, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.ReadyForInput, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.BreakTimeStarted, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.BreakTimeMinReached, OnMessage);

		goodAudio = GetComponents <AudioSource> ()[0];
		weakAudio = GetComponents <AudioSource> ()[1];
		strongAudio = GetComponents <AudioSource> ()[2];

		// good weak strong
	}
	
	void OnDestroy ()
	{
		Manager.messenger.Unsubscribe (BellaMessages.GoodBreath, OnMessage);
		Manager.messenger.Unsubscribe (BellaMessages.WeakBreath, OnMessage);
		Manager.messenger.Unsubscribe (BellaMessages.StrongBreath, OnMessage);
		Manager.messenger.Unsubscribe (BellaMessages.ReadyForInput, OnMessage);
		Manager.messenger.Unsubscribe (BellaMessages.BreakTimeStarted, OnMessage);
		Manager.messenger.Unsubscribe (BellaMessages.BreakTimeMinReached, OnMessage);
	}
	// Update is called once per frame
	void Update () {
		updateBanner ();
//		cheerAudio.clip = Natchar;
//		cheerAudio.Play ();
	}

	void OnMessage (Object sender, string msgID, float num1 = 0f, float num2 = 0f, float num3 = 0f, float num4 = 0f)
	{

		Debug.Log ("started the BearTravel");
		if (msgID == BellaMessages.WeakBreath) {
			Debug.Log ("!!!!!!!!!!!!some weak force");
			meters += 30;
			if(!weakAudio.isPlaying)
			weakAudio.Play();
			
		}
		else if (msgID == BellaMessages.GoodBreath) {
			Debug.Log ("!!!!!!!!!!!!!!!some good force");
			meters += 100;
			if(!goodAudio.isPlaying)
				goodAudio.Play();

		}
		else if (msgID == BellaMessages.StrongBreath) {
			Debug.Log ("!!!!!!!!!!!!!!!!!!!some strong force");
			meters += 50;
			if(!strongAudio.isPlaying)
				strongAudio.Play();

		}
		else if (msgID == BellaMessages.BreakTimeStarted) {
			Debug.Log ("BreakTimeStarted!!!!!!!!");

			Application.LoadLevel("Transition");

		}
		updateText ();

	}

	void updateText(){
		meterDisplay.text = "Meters Traveled: " + meters; 
	}

	void updateBanner(){

		Vector2 bannerVector = new Vector2 (0, 0);
		Vector2 outsideBannerVector = new Vector2 (0, 200);
		if (meters % 200 <= 30 && meters!=0) {
			bannerDisplay.text = meters + " meters!";
//			Debug.Log ();

			GameObject.FindGameObjectWithTag("Banner").transform.position = bannerVector;
		} else {
			bannerDisplay.text = "";
			GameObject.FindGameObjectWithTag("Banner").transform.position = outsideBannerVector;


		}

		}
}
