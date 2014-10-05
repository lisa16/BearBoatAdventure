using UnityEngine;
using System.Collections;

public class FadeOutLungScript : MonoBehaviour {

	private float _lungFadeTicker = 0;

	[SerializeField]
	private float _TimeToFade;
	[SerializeField]
	private float _DurationToFade;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, _TimeToFade+_DurationToFade);
	}
	
	// Update is called once per frame
	void Update () {
		_lungFadeTicker += Time.deltaTime;

		if(_lungFadeTicker > _TimeToFade)
		{
			float percent = (_TimeToFade+_DurationToFade-_lungFadeTicker)/(_DurationToFade);
			Color c = this.gameObject.renderer.material.color;
			this.gameObject.renderer.material.color = new Color(c.r, c.g, c.b, percent);
		}
	}
}
