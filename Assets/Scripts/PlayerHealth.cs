using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    //Variable Declarations
    public GameObject healthbar;
    public float max_health = 100f;
    public float current_health = 0f;
    public int healthLost = 50;
    bool death = false;

	public Animator anim;
      
    void Start ()
    {
        //When the script starts, assign max health to current
        current_health = max_health;
        // InvokeRepeating("decreaseHealth", 1f, 1f);
    }

    void Update()
    {
        if (GameObject.Find("Enemy").GetComponent<Enemy>().attacking == true)
        {
            decreaseHealth();
           // StartCoroutine(decreaseHealthCoroutine());
        }

        if (GameObject.Find("Enemy1").GetComponent<Enemy>().attacking == true)
        {
            decreaseHealth();
            // StartCoroutine(decreaseHealthCoroutine());
        }
        if (GameObject.Find("Enemy2").GetComponent<Enemy>().attacking == true)
        {
            decreaseHealth();
            // StartCoroutine(decreaseHealthCoroutine());
        }

        if (current_health <= 0)
        {
            Death();
        }
    }
    void decreaseHealth()
    {
        current_health = current_health - healthLost;
        //Calculate the health to change in the canvas
        float calculate_health = current_health / max_health;
        setNewHealthBar(calculate_health);
    }
/*
    IEnumerator decreaseHealthCoroutine()
    {
        while (true)
        {
            decreaseHealth();
            yield return new WaitForSeconds(3f);
        }
    }
  */  


    void setNewHealthBar(float change_health)
    {
        //Health is divided and is calculated from the scale of health
        healthbar.transform.localScale = new Vector3(change_health, healthbar.transform.localScale.y,
            healthbar.transform.localScale.z);
    }

    void Death()
    {
		anim.SetBool ("Defeated", true);
        gameObject.GetComponent<PlayerHealth>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        if (gameObject.tag == "Sphere")
        {
            gameObject.GetComponent<SelectObject>().enabled = false;
			gameObject.GetComponent<ClickMove>().enabled = false;
        }
        if (gameObject.tag == "Sphere2")
        {
            gameObject.GetComponent<SelectObject2>().enabled = false;
			gameObject.GetComponent<ClickMove2>().enabled = false;
        }
        healthLost = 0;
        death = true;
        current_health = 0;
        //anim.SetBool ("Defeated", true);
        changeScoreBoard();
    }

    void changeScoreBoard()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().decrementPlayersByOne();
    }
}