using UnityEngine;
using System.Collections;
using BellaProject;
using Bindings;


public class gaugemove : MonoBehaviour {
	int y = this.transform.position.y;

	void Start ()
	{
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
	void Update ()
	{
		void OnMessage (Object sender, string msgID, float num1 = 0f, float num2 = 0f, float num3 = 0f, float num4 = 0f)
		{
			
			Debug.Log ("started the BearTravel");
			if (msgID == BellaMessages.WeakBreath) {
				Debug.Log ("!!!!!!!!!!!!some weak force");
				meters += 3;
				this.transform.position
				
				
			}
			else if (msgID == BellaMessages.GoodBreath) {
				Debug.Log ("!!!!!!!!!!!!!!!some good force");
				meters += 10;
				
			}
			else if (msgID == BellaMessages.StrongBreath) {
				Debug.Log ("!!!!!!!!!!!!!!!!!!!some strong force");
				meters += 5;
				
			}

			
		}
		

		
	}
}
