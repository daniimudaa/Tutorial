using System.Collections;
using UnityEngine;

public class Apple : MonoBehaviour 
{
	public static float bottomY = -20f;


	void Update () 
	{
		// if an apple reaches past -20 units in the Y direction (down)
		if (transform.position.y < bottomY) 
		{
			//Only destroy the object that this instance of the script is attached to
			Destroy (this.gameObject);

			//reference ApplePicker script
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

			//call AppleDestroyed function in ApplePicker script
			apScript.AppleDestroyed();
		}
	}
}
