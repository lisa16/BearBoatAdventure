using UnityEngine;
using System.Collections;
using BellaProject;
using Bindings;

public class gaugemove : MonoBehaviour
{
		float y;
		public const int barlength = 45; //ideally we can do this dynamically
		public int increment;
		public int breaths;

		void Start ()
		{
				y = transform.position.y;
				breaths = 20;
				increment = barlength / breaths;

//		barTop = GameObject.FindGameObjectWithTag ("Gauge").top;
//		barBottom = GameObject.FindGameObjectWithTag ("Gauge").bottom;

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
				if (this.transform.position.y > 5) {
						resetBar ();
				}
		}

		void resetBar ()
		{
				this.transform.position = new Vector2 (this.transform.position.x, -40);
		}

		void OnMessage (Object sender, string msgID, float num1 = 0f, float num2 = 0f, float num3 = 0f, float num4 = 0f)
		{
				float multipler;
			
				Debug.Log ("started the BearTravel");
				if (msgID == BellaMessages.WeakBreath) {
					
						multipler = 0.3f;
						updatePos (multipler * increment);
				} else if (msgID == BellaMessages.GoodBreath) {
						
						multipler = 1.0f;
						updatePos (multipler * increment);		
				} else if (msgID == BellaMessages.StrongBreath) {
						
						multipler = 0.5f;
						updatePos (multipler * increment);		
				} else if (msgID == BellaMessages.SetEnd) {
						resetBar ();	
				}

			
		}

		void updatePos (float meters)
		{
				Debug.Log ("!!!! Update POS !!!");
				this.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y + meters);
		}
		

		
}

