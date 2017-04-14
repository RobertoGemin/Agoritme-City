using UnityEngine;
using System.Collections;

public class checkForkill : MonoBehaviour {

	// Use this for initialization
	public Material defaultMaterial;
	public Material glowMaterial;
	public Material inactiveMaterial;
	
	public GUIText target;
	public GUITexture targetImage;
	public bool itemUsable = true;
	
	public AudioClip itemAudio;
	private bool soundPlayed = false;
	public bool lookon = false;
	public float speed;
	public float timeInterval = 1.0f;
	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody>().velocity = new Vector3(3, 0, 2);
		GetComponent<Renderer>().material = new Material(defaultMaterial);

	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{	

		//float t = (Mathf.Sin(Time.time * speed) + 1f) / 2.0f;

		if (transform.position.y < -30)
		{

			transform.position = new Vector3(0f,30f,0f) ;

		}
		if (lookon = false)
		{
	
		}
			target.text = "";
		GetComponent<Renderer>().material = defaultMaterial;

		targetImage.color = Color.gray;
		if(!itemUsable)
		{
			GetComponent<Renderer>().material = inactiveMaterial;	

		}
	}



	public void OnLookEnter()
	{
		//Debug.Log( "Check");
		if(itemUsable)
		{
			targetImage.color = Color.red;
			target.text = 	Camera.main.GetComponent<keybinding>().dead.ToString()+" balls left";
			//target.text = "Fire";

			GetComponent<Renderer>().material = glowMaterial;
			lookon = true;
			//this.transform.GetComponent<Rigidbody>().useGravity = false;

			GetComponent<Rigidbody>().constraints=	RigidbodyConstraints.FreezeAll;
			StartCoroutine("movementStop", 3.0F);
			this.transform.localScale = new Vector3(2f,2f,2f);
			//RigidbodyConstraints.FreezeAll

			if(Input.GetMouseButtonDown(0))
			{
				//Camera.main.GetComponent<AudioSource>().PlayOneShot(PunchAudioClip);
				Camera.main.GetComponent<keybinding>().killballs();
				//hit.collider.gameObject.GetComponent<checkForkill>().OnLookEnter();
				//Destroy(gameObject);
				itemUsable = false;
				Destroy(gameObject);	
				targetImage.color = Color.gray;
				target.text = "";
				/*if(!soundPlayed)
				{
					audio.clip = itemAudio;
					audio.Play();
					soundPlayed = true;
				}
				
				if(!audio.isPlaying)
				{
					soundPlayed = false;	
				}*/
			}


		}
		else
		{


		}
	}
	IEnumerator movementStop(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		GetComponent<Rigidbody>().constraints =	RigidbodyConstraints.None;
		transform.position = new Vector3(0f,30f,0f) ;
		//go.gameObject.transform.localScale = new Vector3(newpostion,go.gameObject.transform.localScale.y,newpostion);
		this.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
	}

}
