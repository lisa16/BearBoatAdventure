using UnityEngine;
using System.Collections;
using BellaProject;
using Bindings;

public class MoveBearBreathOpp : MonoBehaviour
{

		//private Rigidbody2D;
		// Use this for initialization

		
		public static int v_offset = Random.Range (1, 25);
		public int multi_weak = -1;
		public int multi_strong = -1;
		public int multi_good = -5;

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
				

	
		}

		void OnMessage (Object sender, string msgID, float num1 = 0f, float num2 = 0f, float num3 = 0f, float num4 = 0f)
		{
				int moveGood = multi_good * v_offset;
				int moveStrong = multi_strong * v_offset;
				int moveWeak = multi_weak * v_offset;

				Debug.Log ("started");
				if (msgID == BellaMessages.WeakBreath) {
						Debug.Log ("some weak force");
						resetVelocity ();
						rigidbody2D.velocity = (new Vector2 (0, multi_weak));
				}
				if (msgID == BellaMessages.GoodBreath) {
						Debug.Log ("some weak force");
						resetVelocity ();
						rigidbody2D.velocity = (new Vector2 (0, moveGood));
				}
				if (msgID == BellaMessages.StrongBreath) {
						Debug.Log ("some weak force");
						resetVelocity ();
						rigidbody2D.velocity = (new Vector2 (0, moveStrong));
				}
		}

		void resetVelocity ()
		{
				rigidbody2D.velocity = (new Vector2 (0, 0));
		}
}
