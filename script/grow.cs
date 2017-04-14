using UnityEngine;
using System.Collections;

public class grow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale.Set(5f,5f,5f);
		transform.localScale = new Vector3(5F, 5F, 5F);
	}
}
