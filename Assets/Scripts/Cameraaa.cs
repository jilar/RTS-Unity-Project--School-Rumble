using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraaa : MonoBehaviour {

	public float cameraSpeed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 cameraChange;
		if (Input.GetKey(KeyCode.W)){
			//Debug.LogError("sdfsdf");
			cameraChange= new Vector3(0,0,-cameraSpeed);
			this.transform.position+=cameraChange;
		}
		if (Input.GetKey(KeyCode.S)){
			cameraChange= new Vector3(0,0,cameraSpeed);
			this.transform.position+=cameraChange;
		}
		if (Input.GetKey(KeyCode.A)){
			cameraChange= new Vector3(cameraSpeed,0,0);
			this.transform.position+=cameraChange;
		}
		if (Input.GetKey(KeyCode.D)){
			cameraChange= new Vector3(-cameraSpeed,0,0);
			this.transform.position+=cameraChange;
		}
	}
}
