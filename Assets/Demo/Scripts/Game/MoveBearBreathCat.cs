﻿using UnityEngine;
using System.Collections;
using BellaProject;
using Bindings;

public class MoveBearBreathCat : MonoBehaviour
{

		public static int v_offset = Random.Range (1, 10);
		public int multi_weak = -10;
		public int multi_strong = -10;
		public int multi_good = -50;
		public int catchUp = 10;
		float bearY;
		float awayFromBear;
		float newCatchup;

		void Start ()
		{
				bearY = GameObject.FindGameObjectWithTag ("BEAR").transform.position.y;
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
				awayFromBear = Mathf.Abs (this.transform.position.y - bearY);	
				newCatchup = awayFromBear - v_offset;
				while (awayFromBear > catchUp) {
						//do nothing
						gettingClose ();
				}
				
		}

		void gettingClose ()
		{
				awayFromBear = Mathf.Abs (this.transform.position.y - bearY);	
				newCatchup = awayFromBear - v_offset;
//				Vector2 toPosition = new Vector2 (this.transform.position.x, this.transform.position.y + newCatchup);

				//these are moving cloeser:
				int moveCatchup = 1 * v_offset;
				int reverseCatchup = -1 * v_offset;

				Vector2 vectorCatchup = new Vector2 (0, moveCatchup);
				Vector2 vectorRevCatchup = new Vector2 (0, reverseCatchup);
				if (awayFromBear > catchUp) {
//						this.transform.position = (new Vector2 (this.transform.position.x, this.transform.position.y + newCatchup));
//						transform.position = Vector2.SmoothDamp (transform.position, toPosition, 1000000);
						
						rigidbody2D.AddForce (vectorCatchup);
				} 
				if (awayFromBear < catchUp) {
						rigidbody2D.AddForce (vectorRevCatchup);
				}
				

		}
	
		void OnMessage (Object sender, string msgID, float num1 = 0f, float num2 = 0f, float num3 = 0f, float num4 = 0f)
		{
				int moveGood = multi_good * v_offset;
				int moveStrong = multi_strong * v_offset;
				int moveWeak = multi_weak * v_offset;
		
				Vector2 vectorGood = new Vector2 (0, moveGood);
				Vector2 vectorStrong = new Vector2 (0, moveStrong);
				Vector2 vectorWeak = new Vector2 (0, moveWeak);
		
				Debug.Log ("started");
				if (msgID == BellaMessages.WeakBreath) {
						Debug.Log ("some weak force");
						rigidbody2D.AddForce (vectorWeak);
			
				}
				if (msgID == BellaMessages.GoodBreath) {
						Debug.Log ("some weak force");
						rigidbody2D.AddForce (vectorGood);
				}
				if (msgID == BellaMessages.StrongBreath) {
						Debug.Log ("some weak force");
						rigidbody2D.AddForce (vectorWeak);
				}
		}
}
