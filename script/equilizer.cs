using UnityEngine;
using System.Collections;

public class equilizer : MonoBehaviour {


	//An AudioSource object so the music can be played  
	private AudioSource aSource;  
	//A float array that stores the audio samples  
	public float[] samples = new float[64];  
	//A renderer that will draw a line at the screen  
	private LineRenderer lRenderer;  
	//A reference to the cube prefab  
	public GameObject cube;  
	//The transform attached to this game object  
	private Transform goTransform;  
	//The position of the current cube. Will also be the position of each point of the line.  
	private Vector3 cubePos;  
	//An array that stores the Transforms of all instantiated cubes  
	private Transform[] cubesTransform;  
	//The velocity that the cubes will drop  
	private Vector3 gravity = new Vector3(0.0f,0.25f,0.0f);  

	
	public float timeInterval = 1.0f;
	public float speed = 2.0f;

	
	void Awake ()  
	{  
		this.aSource = GetComponent<AudioSource>();  
		this.goTransform = GetComponent<Transform>();  
		StartCoroutine("giveColour");
	}  


	IEnumerator giveColour()
	{
		while(true)
		{
			for(int i=0; i<9;i++)  
			{  
				GameObject[] gos;
				gos = GameObject.FindGameObjectsWithTag(i.ToString());		
				Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
				foreach (GameObject go in gos)
				{
					go.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.Lerp(go.transform.GetChild(0).GetComponent<Renderer>().material.color,newColor,0.5f);
				}
			
			}
		yield return new WaitForSeconds(1);
		}

	

	}
	
	void Start()  
	{  
 
	}  
	
	void Update ()  
	{  
		aSource.GetSpectrumData(this.samples,0,FFTWindow.BlackmanHarris);  
		GameObject[] balls;
		balls = GameObject.FindGameObjectsWithTag("balls");
		float newsize = Mathf.Clamp(samples[5]*(1+5*5),1f,1.75f);
		foreach (GameObject ballsOfSteel in balls)
		{
			// collison doesnt work then
			//ballsOfSteel.gameObject.transform.localScale = new Vector3(newsize,newsize,newsize);
		}



		for(int i=0; i<8;i++)  
		{  
		
			GameObject[] gos;
			gos = GameObject.FindGameObjectsWithTag(i.ToString());
			float newpostion = Mathf.Clamp(samples[i]*(1+i*i),1f,1.75f);
			foreach (GameObject go in gos)
			{
				float newpostioncheck = go.transform.position.y + newpostion;
				go.gameObject.transform.localScale = new Vector3(newpostion,go.gameObject.transform.localScale.y,newpostion);
			}

		  
		}  
	}  
}  