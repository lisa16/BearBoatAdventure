using UnityEngine;
using System.Collections;

public class ControlFireBreatheScript : MonoBehaviour {

	[SerializeField]
	private ParticleSystem particle;
	private AudioSource huff;
	// Use this for initialization
	void Start () {
		huff = this.GetComponents<AudioSource> ()[0];
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Fire()
	{
		if(!particle.isPlaying)
		{
			particle.Play();
		}
		huff.Play ();
	}
}
