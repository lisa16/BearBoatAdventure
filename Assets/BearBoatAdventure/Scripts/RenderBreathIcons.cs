using UnityEngine;
using System.Collections;
using Bindings;
using BellaProject;
using System.Collections.Generic;

public class RenderBreathIcons : MonoBehaviour {

	[SerializeField]
	private GameObject _goodLungIcon;
	[SerializeField]
	private GameObject _badLungIcon;
	private float _lungIconIndexX;
	private List<GameObject> _breathIconList;

	[SerializeField]
	private ParticleSystem _burst;
	[SerializeField]
	private ParticleSystem _badBurst;

	// Use this for initialization
	void Start ()
	{
		_burst = Instantiate (_burst) as ParticleSystem;
		_badBurst = Instantiate (_badBurst) as ParticleSystem;
		_lungIconIndexX = _goodLungIcon.transform.position.x;
		_breathIconList = new List<GameObject> ();

		Manager.messenger.Subscribe (BellaMessages.BreathEnd, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.GoodBreath, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.WeakBreath, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.StrongBreath, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.ReadyForInput, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.BreakTimeStarted, OnMessage);
		Manager.messenger.Subscribe (BellaMessages.BreakTimeMinReached, OnMessage);	
	}
	void OnDestroy ()
	{
		Manager.messenger.Unsubscribe (BellaMessages.BreathEnd, OnMessage);
		Manager.messenger.Unsubscribe (BellaMessages.GoodBreath, OnMessage);
		Manager.messenger.Unsubscribe (BellaMessages.WeakBreath, OnMessage);
		Manager.messenger.Unsubscribe (BellaMessages.StrongBreath, OnMessage);
		Manager.messenger.Unsubscribe (BellaMessages.ReadyForInput, OnMessage);
		Manager.messenger.Unsubscribe (BellaMessages.BreakTimeStarted, OnMessage);
		Manager.messenger.Unsubscribe (BellaMessages.BreakTimeMinReached, OnMessage);
	}

	void OnMessage (Object sender, string msgID, float num1 = 0f, float num2 = 0f, float num3 = 0f, float num4 = 0f)
	{
		switch (msgID) {

		case BellaMessages.BreathEnd:
			break;
		case BellaMessages.WeakBreath:
			GameObject newBadLungIcon = Instantiate(_badLungIcon) as GameObject;
			_breathIconList.Add (newBadLungIcon);
			
			newBadLungIcon.transform.position = new Vector2(_lungIconIndexX, _badLungIcon.transform.position.y);
			
			_lungIconIndexX += 25;
			if(!_badBurst.isPlaying)
			{
				_badBurst.Play();
			}
			break;
		case BellaMessages.GoodBreath:
			GameObject newGoodLungIcon = Instantiate(_goodLungIcon) as GameObject;
			_breathIconList.Add (newGoodLungIcon);

			newGoodLungIcon.transform.position = new Vector2(_lungIconIndexX, _goodLungIcon.transform.position.y);

			_lungIconIndexX += 25;
			if(!_burst.isPlaying)
			{
				_burst.Play();
			}

			break;
		case BellaMessages.StrongBreath:
			GameObject newBadLungIcon2 = Instantiate(_badLungIcon) as GameObject;
			_breathIconList.Add (newBadLungIcon2);
			
			newBadLungIcon2.transform.position = new Vector2(_lungIconIndexX, _badLungIcon.transform.position.y);
			
			_lungIconIndexX += 25;
			if(!_badBurst.isPlaying)
			{
				_badBurst.Play();
			}
			break;
		case BellaMessages.ReadyForInput:
			break;
		case BellaMessages.BreakTimeStarted:
			break;
		case BellaMessages.BreakTimeMinReached:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
