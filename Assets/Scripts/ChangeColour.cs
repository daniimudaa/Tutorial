using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour 
{
	void FixedUpdate () 
	{
		//*finding the renderer component to get matieral
		Renderer renderer = this.GetComponent<Renderer> ();

		//*setting random colour
		Color newColor = new Color( Random.value, Random.value, Random.value, 0.01f);

		//* applying the random colour to the object's matieral
		renderer.material.color = newColor;     
	}
}
