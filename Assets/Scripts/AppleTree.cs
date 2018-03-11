using System.Collections;
using UnityEngine;

//*added stuff = code that i've implemented outside of the tutorial
//**TUTORIAL = implemented tutorial code

public class AppleTree : MonoBehaviour 
{
	//////**TUTORIAL CODE - editing previous code with my own
	//Apple prefab
	//public GameObject applePrefab;

	//*added stuff - random apple types in place of above code
	public GameObject[] randomApples;

	public GameObject doublePointApple;

	//speed for Apple fall
	public float speed = 1f;

	//distance for AppleTree turns
	public float leftAndRightEdge = 10f;

	// % chance for direction change (AppleTree)
	public float chanceToChangeDirections = 0.1f;

	//Apple instantiating rate
	public float secondsBetweenAppleDrops = 1f;


	void Start () 
	{
		//dropping apples
		InvokeRepeating ("DropApple", 2f, secondsBetweenAppleDrops);

		//dropping doublepoint apples
		InvokeRepeating ("DropDoublePoints", 10.6f, 10.6f);
	}
	
	void Update () 
	{
		//print (speed); //* testing to see how the value changes over time

		//basic AppleTree movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		//changing AppleTree direction
		if (pos.x < -leftAndRightEdge) 
		{
			//move AppleTree right
			speed = Mathf.Abs (speed); 
		} 

		else if (pos.x > leftAndRightEdge) 
		{
			//move AppleTree left
			speed = -Mathf.Abs (speed); 
		} 



	}

	void FixedUpdate()
	{
		//change AppleTree direction randomly
		if (Random.value < chanceToChangeDirections) 
		{
			//change AppleTree direction in opposite 
			speed *= -1; 
		}
	}

	void DropApple()
	{

		//////**TUTORIAL CODE - editing previous code with my own
		////instantiate an Apple obj from the current position of the AppleTree
		//GameObject apple = Instantiate (applePrefab) as GameObject;
		//apple.transform.position = transform.position;

		//*added stuff - random apple types - instantiating random apple prefabs from an array in AppleTree position similar to above
		Instantiate (randomApples[UnityEngine.Random.Range (0,3)], transform.position, transform.rotation);

	}

	void DropDoublePoints()
	{
		Instantiate (doublePointApple, transform.position, transform.rotation);
	}
}
