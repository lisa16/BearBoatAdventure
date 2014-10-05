using UnityEngine;
using System.Collections;

public class ControlFireBreatheScript : MonoBehaviour {

	[SerializeField]
	private ParticleSystem particle;

	// Use this for initialization
	void Start () {
	
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
	}
}
