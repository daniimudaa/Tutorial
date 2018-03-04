using System.Collections;
using UnityEngine;
using System.Text;

public class Basket : MonoBehaviour 
{
	public GUIText scoreGT; //legacy version of UI

	public AppleTree treeScript; //added stuff - difficulty

	public GameObject tree; //added stuff - difficulty

	public int maxApples = 10000;

	void Start () 
	{
		treeScript = tree.GetComponent<AppleTree> ();

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

		//added stuff - difficulty
		for (int i = 0; i < maxApples / 100; i++) 
		{
			if (score == i * 1000) 
			{
				treeScript.speed *= 2;

				//print (treeScript.speed);
			}
		}
				

		if (score == 10000) 
		{
			//win level menu
		}

	}
}
