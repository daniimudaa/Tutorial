using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour 
{
	//static reference so that the same variable can be shared by all instances of the class
	static public int score = 1000;

	void Awake ()
	{
		//if the highscore exists, read it then display it
		if (PlayerPrefs.HasKey ("ApplePickerHighScore")) 
		{
			score = PlayerPrefs.GetInt ("ApplePickerHighScore");
		}

		//assign high score to ApplePickerHighScore
		PlayerPrefs.SetInt("ApplePickerHighScore", score);

	}

	void Update () 
	{
		//getting text componenet & adding score value to the text
		GUIText gt = this.GetComponent<GUIText> ();
		gt.text = "High Score:" + score;

		//update ApplePickerHighScore in PlayerPrefs if necessary
		if (score > PlayerPrefs.GetInt ("ApplePickerHighScore")) 
		{
			PlayerPrefs.SetInt ("ApplePickerHighScore", score);
		}
	}
}
