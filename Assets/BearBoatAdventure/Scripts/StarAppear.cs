using System.Collections;
using UnityEngine;

public class StarAppear : MonoBehaviour {
	
	public GameObject star;
	public GameObject temp_star;
	public float timer = 0f;
	public Vector2 star_pos;
	public float randomTime;
	
	// Use this for initialization
	void makeStarAppear(){
		star_pos = new Vector2 (0f, 0f);
		temp_star = (GameObject) Instantiate(star);
		temp_star.transform.position = star_pos;
		
	}
	
	void Start () {
		randomTime = Random.Range(0f, 5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(timer > randomTime){
			makeStarAppear();
			timer = 0f;	
			randomTime = Random.Range(0f, 30f);
		}
		
		
	}
	
}
