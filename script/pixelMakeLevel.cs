using UnityEngine;
using System.Collections;

public class pixelMakeLevel : MonoBehaviour {

	public Texture2D texImage;
	public BuildingUpdate BuildingScript;
	public int imageLength;
	// Use this for initialization
	void Awake () {
		BuildingScript =GetComponent<BuildingUpdate>();
	}
		
	void Start () {
		imageLength =texImage.height;
		//imageLength = 8;
		int stringname = 1;
		for(int imageX = 0;imageX <imageLength ;imageX++ ) 
		{
			for(int imageY = 0;imageY <imageLength ;imageY++ ) 
			{
				Color32 pixel = texImage.GetPixel(imageX,imageY);
				if (pixel == Color.black)
				{

					string count = stringname.ToString();
					BuildingScript.MakeBuilding(imageX,imageY,count);
				}
				else
				{	
				}
			}
			if (stringname > 8)
			{
				stringname =1;
			}
			else
			{
				stringname++;
			}
		}

		backupFunction();
	}
	
	void backupFunction () {
		GameObject[] newGos;
		newGos = GameObject.FindGameObjectsWithTag("Untagged");		
		foreach (GameObject go in newGos)
		{
			//go.tag = "Untagged" nevermind
		}
	}
}
