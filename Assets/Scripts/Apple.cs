using System.Collections;
using UnityEngine;

//*added stuff = code that i've implemented outside of the tutorial
//**TUTORIAL = implemented tutorial code

public class Apple : MonoBehaviour 
{
	public static float bottomY = -20f;

	//*speed variable for apple fall
	public float appleSpeed = 0.1f;

	void Start ()
	{
		appleSpeed = 0.1f;
	}

	void Update () 
	{
		//*checking speed increase works
		//print (appleSpeed);

		//* makking apples fall faster
		this.GetComponent<Rigidbody> ().AddForce (0, -appleSpeed, 0 , ForceMode.Impulse);

		//*rotaing the obj (aesthetics)
		transform.Rotate (0.5f, Random.Range(5,10), 2f);

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
