using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public float range = 300.0f;
	private GUITexture myGUITexture;
	// Use this for initialization
	void Start() 
	{ // Position the billboard in the center, // but respect the picture aspect ratio 
		int textureHeight = GetComponent<GUITexture>().texture.height;
		int textureWidth = GetComponent<GUITexture>().texture.width;
		int screenHeight = Screen.height;
		int screenWidth = Screen.width;
		
		int screenAspectRatio = (screenWidth / screenHeight);
		int textureAspectRatio = (textureWidth / textureHeight);
		
		int scaledHeight;
		int scaledWidth;
		if (textureAspectRatio <= screenAspectRatio)
		{
			// The scaled size is based on the height
			scaledHeight = screenHeight;
			scaledWidth = (screenHeight * textureAspectRatio);
		}
		else
		{
			// The scaled size is based on the width
			scaledWidth = screenWidth;
			scaledHeight = (scaledWidth / textureAspectRatio);
		}
		float xPosition = screenWidth / 2 - (scaledWidth / 2);
		myGUITexture.pixelInset =
			new Rect(xPosition, scaledHeight - scaledHeight,
			         scaledWidth, scaledHeight);
		
	} 
	void Awake() {
		myGUITexture = this.gameObject.GetComponent("GUITexture") as GUITexture;
	}


	// Update is called once per frame
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

		RaycastHit hit = new RaycastHit();
		
		Debug.DrawRay(ray.origin, ray.direction, Color.green);
		
		if(Physics.Raycast(ray, out hit, range))
		{
			if(hit.collider.gameObject.GetComponent<checkForkill>() != null)
			{
				hit.collider.gameObject.GetComponent<checkForkill>().OnLookEnter();	
			}
		}
	}
}