using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove2 : MonoBehaviour
{
	public Animator anim;
    //Finds the endpoint of the game object's destination 
    private Vector3 end;
    //Boolean to test if the game object has reached the destination
    //Set back to false if game object has not reached destination
    private bool reached = false;
    //The move speed of the character
    public float gameObjectSpeed = 100.0f;
    //Finds the vertical position of the game object
    private float yAxis;
	public float Rotspeed = 3.0f;

    void Start()
    {
        //Make sure to keep the yaxis to not move away. Keep it parallel to the terrain.
        yAxis = gameObject.transform.position.y;
    }



    // Update is called once per frame
    void Update()
    {
        //If Statement: 
        //First Parameter : If left mouse is clicked down
        //Second Paramter : If touch count is greater than one
        //                  Touch struct returned indicates somethign is touched on screen  
        if (((Input.GetMouseButtonDown(0)
            || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            ))
        {
            //Declare a raycast struct
            RaycastHit clickMe;
            //Create a Ray on the destination of the click
            //for unity editor
            //  #if UNITY_EDITOR
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // #endif

            //Check ray if hit any other colliders
            if (Physics.Raycast(ray, out clickMe))
            {
                //Boolean changed to tell game object to keep moving 
                reached = true;

				anim.SetBool ("Moving", true);
                //Assign the location
                end = clickMe.point;
                //Do not move vertical just keep going along the Terrain 
                end.y = yAxis;
            }
        }

        //If the flag is true and the object is cucrently moving and it does not click on same position
        if (reached && !Mathf.Approximately(gameObject.transform.position.magnitude, end.magnitude))
        {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(end
				- transform.position), Rotspeed * Time.deltaTime);
            //Move the gameobject's position to the clicked destination at speed declared
            //Vector Lerp: 
            //  First Parameter: The Source
            //  Second Parameter: Where the endpoint is 
            //  Third Parameter: Amount of time to reach teh destination 
            //Multiplied to make sure that the speed will always remain constant
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
                end, 1 / (gameObjectSpeed * (Vector3.Distance(gameObject.transform.position, end))));
        }

        //If the destination is equal to the game object's position
        else if (reached && Mathf.Approximately(gameObject.transform.position.magnitude, end.magnitude))
        {
            //Set the bool to false, the character object can no longer move. 
            reached = false;
			anim.SetBool ("Moving", false);
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            gameObject.GetComponent<ClickMove2>().enabled = false;
            gameObject.GetComponent<SelectObject2>().inMotion = false;
        }
    }

}

