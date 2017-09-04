using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    //Variable Declarations
    public GameObject healthbar;
    public float max_health = 100f;
    public float current_health = 0f;
	public float damage;
    public bool death = false;

	public Animator anim;
	public Animator player;

    void Start()
    {
        //When the script starts, assign max health to current
        current_health = max_health;
        //InvokeRepeating("decreaseHealth", 1f, 1f);
    }

    void Update()
    {
        if(gameObject != null)
            {
            if (current_health <= 0)
            {
                Death();
            }
        }
    }

	public IEnumerator decreaseHealth()
	{
		while (current_health > 0) {
			current_health = current_health - damage;
			//Calculate the health to change in the canvas
			float calculate_health = current_health / max_health;
			setNewHealthBar (calculate_health);
			yield return new WaitForSeconds (.3f);
		}
	}

//    public void decreaseHealth()
//    {
//		current_health = current_health - damage;
//        //Calculate the health to change in the canvas
//        float calculate_health = current_health / max_health;
//        setNewHealthBar(calculate_health);
//    }

    void setNewHealthBar(float change_health)
    {
        //Health is divided and is calculated from the scale of health
        healthbar.transform.localScale = new Vector3(change_health, healthbar.transform.localScale.y,
            healthbar.transform.localScale.z);
    }

    void Death()
    {
        death = true;
        gameObject.GetComponent<EnemyHealth>().enabled = false;
        gameObject.GetComponent<Enemy>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<Enemy>().attacking = false;
        changeScoreBoard();
		anim.SetBool ("Defeated", true);
		player.SetBool("Attacking", false);
        //Destroy(gameObject);
    }

    void changeScoreBoard()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().decrementEnemiesByOne();
    }
}
