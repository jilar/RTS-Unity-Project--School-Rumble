using UnityEngine;
using System.Collections;

public class PlayerHealth2 : MonoBehaviour
{
    //Variable Declarations
    public GameObject healthbar;
    public float max_health = 100f;
    public float current_health2 = 0f;
    public int healthLost2 = 50;
    bool death = false;

    public Animator anim;

    void Start()
    {
        //When the script starts, assign max health to current
        current_health2 = max_health;
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

            if (current_health2 <= 0)
            {
                Death();
            }

    }

    void decreaseHealth()
    {
        current_health2 = current_health2 - healthLost2;
        //Calculate the health to change in the canvas
        float calculate_health = current_health2 / max_health;
        setNewHealthBar(calculate_health);
    }


    void setNewHealthBar(float change_health)
    {
        //Health is divided and is calculated from the scale of health
      
        healthbar.transform.localScale = new Vector3(change_health, healthbar.transform.localScale.y,
            healthbar.transform.localScale.z);
    
    }

    void Death()
    {
        anim.SetBool ("Defeated", true);
        gameObject.GetComponent<PlayerHealth2>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<SelectObject2>().enabled = false;
        healthLost2 = 0;
        death = true;
        current_health2 = 0;
    }
}