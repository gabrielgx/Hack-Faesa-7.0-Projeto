using UnityEngine;
using System.Collections;

 
[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MouseOrbitZoom : MonoBehaviour {
 
	public static Quaternion rotation;
    public Transform target;
    float distance = 450f;
    float xSpeed = 1f;
    float ySpeed = 100.0f;
 
    float AngleMin = 10f;
    float AngleMax = 30f;
 
    float SizeMin = 20f;
    float SizeMax = 150f;
	

	public static float fov = 120;
 
    float x = 0.0f;
    float y = 0.0f;
 
	// Use this for initialization
	void Start () {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
		rotation = SmoothLookAt2.rotation;
		//transform.position.z = -422.8617f;
		//transform.position.y = 153.9091f;
		target = GameObject.Find("SolEsfera").transform;	
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
		this.enabled = true;
	}
 
    void LateUpdate () {
    if (target){
			if (Input.GetButton ("Fire1")) {
				
				x += Input.GetAxis("Mouse X") * xSpeed * distance *  0.02f; //distance *
				//x += Input.ge * xSpeed * distance *  0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;


        y = ClampAngle(y, AngleMin, AngleMax);
			}
			rotation = Quaternion.Euler(y, x, SmoothLookAt2.rotation.z);
			
		      	
				fov -= Input.GetAxis("Mouse ScrollWheel") * 20f;
			    fov = Mathf.Clamp(fov, SizeMin, SizeMax);
                this.GetComponent<Camera>().orthographicSize = fov;
    			SmoothLookAt2.fov = fov;
				
			
       // RaycastHit hit;
       // if (Physics.Linecast (target.position, transform.position, out hit)) {
        //        distance -=  hit.distance;
       // }
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;
 
       transform.rotation = rotation;		
       transform.position = position;
			
		
 
    }
 
}
 
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
 
 
}