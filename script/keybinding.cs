using UnityEngine;
using System.Collections;

public class keybinding : MonoBehaviour {

	public int dead = 10;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("t")) exit();
		if (Input.GetKey("r")) reset();
	}

	public void killballs()
	{
		dead--;
		if (dead < 1)
		{
			// game over
			Application.Quit();

		}

	}


	void exit(){
		Application.Quit();
	}
	
	void reset(){
		Application.LoadLevel(0);
	}
}
