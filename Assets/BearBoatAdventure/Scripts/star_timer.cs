using UnityEngine;
using System.Collections;

public class star_timer : MonoBehaviour {
	
	public float star_time;
	// Use this for initialization
	void Start () {
		star_time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		star_time = star_time + Time.deltaTime;
		if (star_time > 20f){
			Destroy (this.gameObject);
		}
	}
}