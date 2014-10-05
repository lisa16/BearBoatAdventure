using UnityEngine;
using System.Collections;
using BellaProject;
using Bindings;

public class gaugemove : MonoBehaviour
{
	float y;
	public const int barlength = 45; //ideally we can do this dynamically
	private int increment;
	private int breaths;

	private float barMovementTicker = 0;

	private Vector2 initVector;
	private Vector2 finalVector;

	private bool isArrowMoving = false;

	void Start ()
	{
		initVector = new Vector2 (this.transform.position.x, this.transform.position.y);
		finalVector = new Vector2 (this.transform.position.x, this.transform.position.y);

		y = transform.position.y;
		breaths = 20;
		increment = barlength / breaths;

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
		if(isArrowMoving)
		{
			barMovementTicker += Time.deltaTime;
		}

		Vector2 newPos = Vector2.Lerp (initVector, finalVector, barMovementTicker);
		this.transform.position = newPos;

		if (this.transform.position.y > 5)
		{
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
		if (msgID == BellaMessages.WeakBreath)
		{
			multipler = 0.3f;
			updatePos (multipler * increment);
		}
		else if (msgID == BellaMessages.GoodBreath)
		{
			multipler = 1.0f;
			updatePos (multipler * increment);		
		}
		else if (msgID == BellaMessages.StrongBreath)
		{
			multipler = 0.5f;
			updatePos (multipler * increment);		
		}
		else if (msgID == BellaMessages.SetEnd)
		{
			resetBar ();	
		}
	}

	void updatePos (float meters)
	{
		isArrowMoving = true;
		barMovementTicker = 0;

		initVector = finalVector;
		finalVector = new Vector2(finalVector.x, finalVector.y + meters);
	}
}

