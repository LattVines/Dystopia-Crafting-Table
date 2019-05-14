using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour {
	public float seconds = 2f;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, seconds);	
	}
	

}
