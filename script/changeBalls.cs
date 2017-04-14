using UnityEngine;
using System.Collections;

public class changeBalls : MonoBehaviour {

	public float speed;
	public float timeInterval = 1.0f;
	public Material defaultMaterial;
	public Material [] ArrdefaultMaterial;
	public Color [] newColor;
	void Start () {
		for(int a = 0; a <ArrdefaultMaterial.Length;a++ )
		{
			ArrdefaultMaterial[a].color =  new Color( 0	, 0,0, 1.0f );
		}
		StartCoroutine("giveColour");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator giveColour()
	{	


		float timer = 0.0f;

		for(int a = 0; a <ArrdefaultMaterial.Length;a++ )
		{

		
			float x = Random.Range(1, 6);
			if (x == 1)
			{
				newColor[a] = new Color( 255f, 0f,0f, 1.0f );
			}
			else if (x == 2)
			{
				newColor[a] = new Color( 255f, 0f,255f, 1.0f );
			}
			else if (x == 3)
			{
				newColor[a] = new Color( 255f, 255f,0f, 1.0f );
			}
			else if (x == 4)
			{
				newColor[a] = new Color( 125, 150f,255f, 1.0f );
			}
			else
			{
				newColor[a] = new Color( 0f, 0f,0f, 1.0f );
			}

		}
			//	Color color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
			while (timer < timeInterval)
			{
				timer += Time.deltaTime * speed;
					for(int a = 0; a <ArrdefaultMaterial.Length;a++ )
					{
					ArrdefaultMaterial[a].color = Color.Lerp(ArrdefaultMaterial[a].color, newColor[a], timer);
					}
				yield return null;
			}

		// On finish recursively call the same routine
		StartCoroutine(giveColour());
		
	}
}
