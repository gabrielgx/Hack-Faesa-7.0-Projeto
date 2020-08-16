using UnityEngine;
using System.Collections;

public class Lua : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.RotateAround (Terra.te, Vector3.up, -60 * Time.deltaTime);
		
	
		
	}
}
