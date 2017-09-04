using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
	public Animator anim;
    private Vector3 end;
    private float yAxis;
    public bool inMotion = false;
    public GameObject enemy1, enemy2, enemy3;
    Transform transformEnemy1, transformEnemy2, transformEnemy3;
    public int attackDistance = 5;
    public float Rotspeed = 1000f;

    // Use this for initialization
    void Start()
    {
        transformEnemy1 = GameObject.FindGameObjectWithTag("Enemy").transform;
        transformEnemy2 = GameObject.FindGameObjectWithTag("Enemy1").transform;
        transformEnemy3 = GameObject.FindGameObjectWithTag("Enemy2").transform;
        //player2 = GameObject.FindGameObjectWithTag("Sphere2").transform;
        //GameObject enemy1 = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse is down");
            //Indicates the destination of the raycast
            // RaycastHit hitInfo = new RaycastHit();
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                Debug.Log(hitInfo.transform.gameObject.tag == "Sphere");
                if (hitInfo.transform.gameObject.tag == "Sphere"
                //  && GameObject.Find("Sphere").GetComponent<SelectObject>().inMotion == false
                )
                {
                    inMotion = true;

                    gameObject.GetComponent<ClickMove>().enabled = true;
                }

                if (hitInfo.transform.gameObject.tag == "Enemy")
                {
					
                    Debug.Log("You hit the enemy!");
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transformEnemy1.position
- transform.position), Rotspeed * Time.deltaTime);

					if (Vector3.Distance (transformEnemy1.position, gameObject.transform.position) < attackDistance
					                   && enemy1.GetComponent<EnemyHealth> ().death != true) {
						anim.SetBool ("Attacking", true);
						Debug.Log ("It should decrement");

						StartCoroutine(enemy1.GetComponent<EnemyHealth> ().decreaseHealth ());
					}
					if (enemy1.GetComponent<EnemyHealth> ().death == true) {
						anim.SetBool ("Attacking", false);
					}
                }

                if (hitInfo.transform.gameObject.tag == "Enemy1")
                {
                    Debug.Log("You hit the enemy1!");

                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transformEnemy1.position
- transform.position), Rotspeed * Time.deltaTime);

                    if (Vector3.Distance(transformEnemy2.position, gameObject.transform.position) < attackDistance
						&& enemy2.GetComponent<EnemyHealth> ().death != true)
                    {
						anim.SetBool ("Attacking", true);
                        Debug.Log("It should decrement");
                        //GameObject.Find("Enemy").GetComponent<EnemyHealth>().
                        //GameObject.Find("Enemy").GetComponent<EnemyHealth>().decreaseHealth();
                        //enemy2.GetComponent<EnemyHealth>().decreaseHealth();
						StartCoroutine(enemy2.GetComponent<EnemyHealth>().decreaseHealth());
					}
					if (enemy2.GetComponent<EnemyHealth> ().death == true) {
						anim.SetBool ("Attacking", false);
					}

                }

                if (hitInfo.transform.gameObject.tag == "Enemy2")
                {
                    Debug.Log("You hit the enemy2!");
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transformEnemy1.position
- transform.position), Rotspeed * Time.deltaTime);

                    if (Vector3.Distance(transformEnemy3.position, gameObject.transform.position) < attackDistance
						&& enemy3.GetComponent<EnemyHealth> ().death != true)
                    {
						anim.SetBool ("Attacking", true);
                        Debug.Log("It should decrement");
                        //enemy3.GetComponent<EnemyHealth>().decreaseHealth();
						StartCoroutine(enemy3.GetComponent<EnemyHealth>().decreaseHealth());
					}
					if (enemy3.GetComponent<EnemyHealth> ().death == true) {
						anim.SetBool ("Attacking", false);
					}
                }

//			//type here
//				if (hitInfo.transform.gameObject.tag == "Enemy" && enemy1.GetComponent<EnemyHealth> ().death == true) {
//					anim.SetBool ("Attacking", false);
//				} else if (enemy2.GetComponent<EnemyHealth> ().death == true) {
//					anim.SetBool ("Attacking", false);
//				} else if (hitInfo.transform.gameObject.tag == "Enemy2" && enemy3.GetComponent<EnemyHealth> ().death == true) {
//					anim.SetBool ("Attacking", false);
//				}
            }
        }
    }
}

