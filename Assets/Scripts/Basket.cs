using System.Collections;
using UnityEngine;
using System.Text;

public class Basket : MonoBehaviour 
{
	public GUIText scoreGT; //legacy version of UI

	public AppleTree treeScript; //my own - difficulty

	public GameObject tree;

	void Start () 
	{
		//score obj reference
		GameObject scoreGO = GameObject.Find ("ScoreCounter");

		//get the GUIText component of found obj
		scoreGT = scoreGO.GetComponent<GUIText>();

		//set start points to 0
		scoreGT.text = "0";

	}
	
	void Update () 
	{
		//Get current screen position of the mouse
		Vector3 mousePos2D = Input.mousePosition;

		//setting how far you can push the mouse in 3D space using the Cameras z position
		mousePos2D.z = -Camera.main.transform.position.z;

		//convert the point from 2D to 3D
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		//moving the basket to the mouse point pos on x axis
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	
	}

	void OnCollisionEnter (Collision col)
	{
		//finding the tag name of what hit this basket
		GameObject collidedWith = col.gameObject;

		//if an object tagged "Apple" touches the baskets collider
		if (collidedWith.tag == "Apple") 
		{
			//destroy that particular Apple obj
			Destroy (collidedWith);
		}

		//parse GUItext into ints
		int score = int.Parse (scoreGT.text);

		//add points when catching an Apple
		score += 100;

		//convert score back to string and display it
		scoreGT.text = score.ToString();

		//tracking high score
		if (score > HighScore.score) 
		{
			HighScore.score = score;
		}

		//my own - difficulty
		if (score % 1000 == 0) 
		{
			//get script
			treeScript = tree.GetComponent<AppleTree> ();

			//print test to see if working
			print ("SPEEDING UP");

			//plus speed to current speed
			treeScript.speed = 200f;

			//print test to see if working
			print ("SPEEDING UP MORE");
		}
	}
}
