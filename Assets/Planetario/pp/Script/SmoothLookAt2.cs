// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class SmoothLookAt2 : MonoBehaviour {
public static Transform target;
public bool smooth= true;
public static float fov;
public static Quaternion rotation;



void  LateUpdate (){
	if (target) {
		if (smooth)
		{
			// Look at and dampen the rotation
			rotation = Quaternion.LookRotation(target.position + new Vector3(0,0,0) - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 1.0f);
				
				
		      
				//fov -= Input.GetAxis("Mouse ScrollWheel") * 20f;
				fov = Mathf.Clamp(fov, 20, 150);
				this.GetComponent<Camera>().orthographicSize = fov;


				
		}
		else
		{
			// Just lookat
		    transform.LookAt(target);
		}
	}
}

void  Start (){
		fov = 150;
		target = GameObject.Find("SolEsfera").transform;
	// Make the rigid body not change rotation
   	if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
}
}