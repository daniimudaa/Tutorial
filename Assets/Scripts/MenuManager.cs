using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour 
{
	public GameObject winPanel;
	public GameObject deathPanel;
	public GameObject pausePanel;
	public GameObject buttons;


	void Start ()
	{
		winPanel.SetActive (false);
		deathPanel.SetActive (false);
		pausePanel.SetActive (false);
		buttons.SetActive (false);
	}

	public void StartGame()
	{
		SceneManager.LoadScene ("_Scene_0");
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void Quit()
	{
		Application.Quit ();
		EditorApplication.Exit (0);
	}

	public void Instructions()
	{
		SceneManager.LoadScene ("Instructions");
	}

	public void Back()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void Retry()
	{
		SceneManager.LoadScene ("_Scene_0");
	}

}
