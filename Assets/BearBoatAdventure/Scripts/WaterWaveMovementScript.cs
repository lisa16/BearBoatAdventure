using UnityEngine;
using System.Collections;

public class WaterWaveMovementScript : MonoBehaviour {

	private Vector2 initPos;
	private Vector2 finalPos;

	private float moveTicker = 0;


	// Use this for initialization
	void Start () {
		initPos = new Vector2(this.transform.position.x, this.transform.position.y);
		finalPos = new Vector2(this.transform.position.x, this.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		moveTicker += Time.deltaTime;

		this.transform.position = new Vector2 (initPos.x + Mathf.Sin (moveTicker *2f), initPos.y + Mathf.Sin (moveTicker*3f));
	}
}
