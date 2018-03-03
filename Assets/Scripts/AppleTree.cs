using System.Collections;
using UnityEngine;

public class AppleTree : MonoBehaviour 
{
	//Apple prefab
	public GameObject applePrefab;

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
	}
	
	void Update () 
	{
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
		//instantiate an Apple obj from the current position of the AppleTree
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
	}
}
