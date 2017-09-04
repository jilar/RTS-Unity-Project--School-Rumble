using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Animator anim;
	//Transform detects movement
	Transform player, player2;
	public float Rotspeed = 3.0f;
	public float moveSpeed = 3.0f;
	public int distance = 5;
	public int attackDistance = 5;
    public bool attacking = false;

	void Start()
	{
		//Target the person with the gameobject player 
		anim.SetBool ("Moving", false);
		player = GameObject.FindGameObjectWithTag("Sphere").transform;
		player2 = GameObject.FindGameObjectWithTag ("Sphere2").transform;

	}

	// Update is called once per frame
	void Update()
	{
		//Quanternion rotation
		//--Look at the player 
		//----Rotate From, To the player's position - monster position, rotate by time per frame
		if (player != null || player2 != null) { 

			if (Vector3.Distance (player.position, gameObject.transform.position) < distance) {
				anim.SetBool ("Moving", true);
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (player.position
				- transform.position), Rotspeed * Time.deltaTime);

				//---Move Foward by speed multilied by times by frame  
				//--Move to player
				transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;

				if (Vector3.Distance (player.position, gameObject.transform.position) < attackDistance) {
                    attacking = true;
                    anim.SetBool ("Attacking", true);
					Debug.Log ("ATTACKING");

					moveSpeed = 0f;
				} else if (Vector3.Distance (player.position, gameObject.transform.position) < distance) {
                    attacking = false;
                    anim.SetBool ("Attacking", false);
					moveSpeed = 3.0f;
				}

			} else if (Vector3.Distance (player2.position, gameObject.transform.position) < distance) {
				anim.SetBool ("Moving", true);
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (player2.position
				- transform.position), Rotspeed * Time.deltaTime);
				//---Move Foward by speed multilied by times by frame  
				//--Move to player
				transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;

				if (Vector3.Distance (player2.position, gameObject.transform.position) < attackDistance) {
					anim.SetBool ("Attacking", true);
                    attacking = true;
					moveSpeed = 0f;
				} else if (Vector3.Distance (player2.position, gameObject.transform.position) < distance) {
					anim.SetBool ("Attacking", false);
                    attacking = false;
					moveSpeed = 3.0f;
				}

			} else {
				Debug.Log ("Else is hit!! LMAO");
				anim.SetBool ("Attacking", false);
				anim.SetBool ("Moving", false);
                attacking = false;
			}
		}
	}
}

