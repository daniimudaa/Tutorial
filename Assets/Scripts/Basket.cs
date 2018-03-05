using System.Collections;
using UnityEngine;
using System.Text;

//*added stuff = code that i've implemented outside of the tutorial
//**TUTORIAL = implemented tutorial code

public class Basket : MonoBehaviour 
{
	public GUIText scoreGT; //legacy version of UI

	//*added stuff
	public AppleTree treeScript; //*added stuff - difficulty - script reference
	public GameObject tree; //*added stuff - difficulty - object containing script reference
	public int maxApples = 10000; //*added stuff - difficulty - maxScore/Apples you can get

	public GameObject eventS;//*added stuff - reference to menu manager
	private MenuManager menuM;//*added stuff - reference to menu manager

	public AudioClip caught; //*audioClip source
	public AudioClip minusPoints; //*audioClip source
	public AudioClip speedUp; //*audioClip source
	public AudioClip speedUp2; //*audioClip source
	AudioSource audioSource; //*audio source on object

	void Start () 
	{
		audioSource = GetComponent<AudioSource> ();

		menuM = eventS.GetComponent<MenuManager>();//*defining script for menu manager

		//*added stuff - locating the scipt reference
		tree = GameObject.Find ("AppleTree"); //*added stuff - difficulty 
		treeScript = tree.GetComponent<AppleTree> (); //*added stuff - difficulty

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
		if (collidedWith.tag == "Apple" || collidedWith.tag == "BadApple") 
		{
			//destroy that particular Apple obj
			Destroy (collidedWith);
		}

		//parse GUItext into ints
		int score = int.Parse (scoreGT.text);

		//add points when catching an Apple
		score += 100;

		if (collidedWith.tag == "Apple") 
		{
			//*play caught audio
			audioSource.PlayOneShot (caught, 1f);
		}

		//*added stuff - bad apple
		//if basket touches a bad apple you loose 100 points
		if (collidedWith.tag == "BadApple")
		{
			score -= 200;

			//*play minusPoints audio
			audioSource.PlayOneShot(minusPoints, 1f);
		}

		//convert score back to string and display it
		scoreGT.text = score.ToString();

		//tracking high score
		if (score > HighScore.score) 
		{
			HighScore.score = score;
		}

		////*added stuff - difficulty
		//*for every 10 apples collected (1000 score) then increase AppleTree speed by 5f
		for (int i = 0; i < maxApples / 100; i++) 
		{
			if (score == i * 1000) 
			{
				//*treeScript.speed += 5f; //this was causing the tree to slow down when in negative value (moving left) because it was adding positive numbers to a negative

				//*if the speed is a positive number then add 5
				if (treeScript.speed > 0) 
				{
					treeScript.speed += 5f;

					//*play speed up audio
					audioSource.PlayOneShot (speedUp, 1f);
				}

				//*if the speed is a negative number then minus 5
				else if (treeScript.speed < 0) 
				{
					treeScript.speed -= 5f;

					//*play speed up audio
					audioSource.PlayOneShot (speedUp2, 1f);
				}
			}
		}
				
		//*added stuff - end game
		//*if end score is reached (10, 000 score) then show win menu screen & pause movement
		if (score == 10000) 
		{
			Time.timeScale = 0;

			//find the scripts that hold the UI panel & buttons
			eventS = GameObject.Find ("EventSystem"); 
			menuM = eventS.GetComponent<MenuManager> (); 

			//turn on the UI Panel and Buttons
			menuM.winPanel.SetActive (true);
			menuM.buttons.SetActive (true);

		}

	}
}
