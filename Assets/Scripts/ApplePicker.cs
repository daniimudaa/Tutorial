using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour 
{
	//Basket References
	public GameObject basketPrefab; //basket obj reference (prefab)
	public int numBaskets = 3; //how many baskets to instantiate
	public float basketBottomY = -14f; //where to instantiate the basket
	public float basketSpacingY = 2f; //instantiate baskets underneith at this distance

	public List<GameObject> basketList;

	void Start () 
	{
		//defining whats stored in the list
		basketList = new List<GameObject>();

		//instantiating 3 baskets in scene at the start
		for (int i = 0; i < numBaskets; i++) 
		{
			//instantiating the basket prefabs
			GameObject tBasketGO = Instantiate (basketPrefab) as GameObject;

			//position of the baskets under each other/spacing between them
			Vector3 pos = Vector3.zero; 
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;

			//add baskets to the list
			basketList.Add (tBasketGO);
		}
	}
	
	void Update () 
	{
		
	}

	public void AppleDestroyed()
	{
		//create an array of all in game obj's with "Apple" tag
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag ("Apple");

		//destroy all falling apples found
		foreach (GameObject tGO in tAppleArray) 
		{
			Destroy (tGO);
		}

		//Destroy one of the baskets
		//get index of the last Basket in basketList
		int basketIndex = basketList.Count-1;

		//get reference to that basket obj
		GameObject tBasketGO = basketList[basketIndex];

		//remove basket from list then destroy obj
		basketList.RemoveAt(basketIndex);
		Destroy (tBasketGO);

		//restart game, but keep highscore
		if (basketList.Count == 0) 
		{
			Application.LoadLevel ("_Scene_0"); //old way of loading scenes
		}

	}
}
