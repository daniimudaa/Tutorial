using System.Collections;
using UnityEngine;

//*added stuff = code that i've implemented outside of the tutorial
//**TUTORIAL = implemented tutorial code

public class Apple : MonoBehaviour 
{
	public static float bottomY = -20f;

	void Update () 
	{
		//*rotaing the obj (aesthetics)
		transform.Rotate (0, 0, Random.Range(5,10), Space.World);

		// if an apple reaches past -20 units in the Y direction (down)
		if (transform.position.y < bottomY) 
		{
			//Only destroy the object that this instance of the script is attached to
			Destroy (this.gameObject);


			if (this.tag == "Apple") //*added stuff - bad apple
			{
				////**TUTORIAL CODE
				//reference ApplePicker script
				ApplePicker apScript = Camera.main.GetComponent<ApplePicker> ();

				////**TUTORIAL CODE
				//call AppleDestroyed function in ApplePicker script
				apScript.AppleDestroyed ();
			}
		}
	}
}
