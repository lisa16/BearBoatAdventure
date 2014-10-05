using UnityEngine;
using System.Collections;
using BellaProject;
using Bindings;

public class MoveBearBreathCat : MonoBehaviour
{

		public static int v_offset;
		public int multi_weak = -10;
		public int multi_strong = -10;
		public int multi_good = -50;
		public int catchUp = 10;
		float bearY;

	float burstTicker = 0;
//		float awayFromBear;
//		float newCatchup;
	[SerializeField]
	private ParticleSystem _burst;
	[SerializeField]
	private ParticleSystem _badBurst;

	private int _numOfAccels = 0;

		void Start ()
		{
		v_offset = Random.Range (1, 10);

		_burst = Instantiate (_burst) as ParticleSystem;
		_burst.transform.position = new Vector2 (this.transform.position.x, _burst.transform.position.y);
		_burst.transform.parent = this.gameObject.transform;
		_badBurst = Instantiate (_badBurst) as ParticleSystem;
		_badBurst.transform.position = new Vector2 (this.transform.position.x, _badBurst.transform.position.y);
		_badBurst.transform.parent = this.gameObject.transform;

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
		burstTicker += Time.deltaTime;
		if(burstTicker > 2f)
		{
			burstTicker = 0;
			_numOfAccels++;
		}

		if(_numOfAccels>0)
		{
			_numOfAccels--;
			float distanceAheadOfBear = this.transform.position.y - bearY;

			if(distanceAheadOfBear>catchUp)
			{
				//Ahead of bear too much, need to slow down!!!
				if(Random.Range(0f,1f)>0.95f)
				{
					//5%chance to do good boost, else do bad boost
					rigidbody2D.AddForce (new Vector2(0,multi_good*-1));
					if(!_burst.isPlaying)
					{
						_burst.Play();
					}
				}
				else{
					rigidbody2D.AddForce (new Vector2(0,multi_weak*-1));
					if(!_badBurst.isPlaying)
					{
						_badBurst.Play();
					}
				}
			}
			else if(distanceAheadOfBear < -catchUp)
			{
				//behind bear too much, need to speed up!!!
				if(Random.Range(0f,1f)>0.05f)
				{
					//95%chance to do good boost, else do bad boost
					rigidbody2D.AddForce (new Vector2(0,multi_good*-1));
					if(!_burst.isPlaying)
					{
						_burst.Play();
					}
				}
				else{
					rigidbody2D.AddForce (new Vector2(0,multi_weak*-1));
					if(!_badBurst.isPlaying)
					{
						_badBurst.Play();
					}
				}
			}
			else
			{
				//within the right range from the bear, average speed!!
				if(Random.Range(0f,1f)>0.5f)
				{
					//5%chance to do good boost, else do bad boost
					rigidbody2D.AddForce (new Vector2(0,multi_good*-1));
					if(!_burst.isPlaying)
					{
						_burst.Play();
					}
				}
				else{
					rigidbody2D.AddForce (new Vector2(0,multi_weak*-1));
					if(!_badBurst.isPlaying)
					{
						_badBurst.Play();
					}
				}
			}
		}

//				awayFromBear = this.transform.position.y - bearY;
			
//				if (Mathf.Abs (awayFromBear) > catchUp) {
//					if (awayFromBear < catchUp) {
//								//do nothing
//								gettingClose ();
//						} else if(awayFromBear > catchUp){
//								gettingAway ();
//						}
//				}
				
		}

//		void gettingAway ()
//		{
//				float reverseCatchup = -1 * v_offset;
//				Vector2 vectorRevCatchup = new Vector2 (0f, reverseCatchup);
//				rigidbody2D.AddForce (vectorRevCatchup);
//		}
//	
//		void gettingClose ()
//		{
//				float moveCatchup = 1 * v_offset;
//				Vector2 vectorCatchup = new Vector2 (0f, moveCatchup);
//				rigidbody2D.AddForce (vectorCatchup);
//		}
	
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
				else if (msgID == BellaMessages.GoodBreath) {
						Debug.Log ("some weak force");
						rigidbody2D.AddForce (vectorGood);
				}
				else if (msgID == BellaMessages.StrongBreath) {
						Debug.Log ("some weak force");
						rigidbody2D.AddForce (vectorStrong);
				}
		}
}
