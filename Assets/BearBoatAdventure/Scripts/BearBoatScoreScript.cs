using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BearBoatScoreScript : MonoBehaviour {

	public int BearBoatScore = 0;
	Text scoreText;

	[SerializeField]
	private string scoreString = "";

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
		scoreText.text = string.Format (scoreString, BearBoatScore);
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range(0f,1f)<0.1f)
		{
			AddScore(1);
		}
	}

	public void AddScore(int score)
	{
		BearBoatScore += score;

		scoreText.text = string.Format (scoreString, BearBoatScore);
	}
}
