using UnityEngine;
using System.Collections;
using BellaProject;
using Bindings;

public class BearTravel : MonoBehaviour {
	private int meters;
	public UnityEngine.UI.Text meterDisplay;

	void Start ()
	{
		meters = 0;
		meterDisplay.text = "Ready";
		Manager.messenger.Subscribe (BellaMessages.GoodBreath, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.WeakBreath, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.StrongBreath, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.ReadyForInput, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.BreakTimeStarted, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.BreakTimeMinReached, OnMessage);
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
	
	}

	void OnMessage (Object sender, string msgID, float num1 = 0f, float num2 = 0f, float num3 = 0f, float num4 = 0f)
	{

		Debug.Log ("started the BearTravel");
		if (msgID == BellaMessages.WeakBreath) {
			Debug.Log ("!!!!!!!!!!!!some weak force");
			meters += 30;

			
		}
		else if (msgID == BellaMessages.GoodBreath) {
			Debug.Log ("!!!!!!!!!!!!!!!some good force");
			meters += 100;

		}
		else if (msgID == BellaMessages.StrongBreath) {
			Debug.Log ("!!!!!!!!!!!!!!!!!!!some strong force");
			meters += 50;

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
}
