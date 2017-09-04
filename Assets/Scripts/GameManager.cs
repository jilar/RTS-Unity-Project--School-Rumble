using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	public Text playersRemaining;
	public Text enemiesRemaining;
	public Text	endText;

    //public GameObject canvas;

	//public GameObject[] enemies;
	public GameObject player1;
	public GameObject player2;

    int allEnemies = 3;
    int maxEnemies = 3;

	int playerCount = 1;
	int enemyCount;
	public Animator anim;
	// Use this for initialization
	void start(){
        //enemies = GameObject.FindGameObjectsWithTag ("Enemy");
        //Text text = canvas.
        Debug.Log("Score activated");
        enemyCount = 0;
        playerCount = 0;

        scoreBoard();
	}
	// Update is called once per frame
	void Update () {
		
	}

    public void decrementEnemiesByOne()
    {
        allEnemies = allEnemies - 1;
        scoreBoard();
    }

    public void decrementPlayersByOne()
    {
        playerCount = playerCount - 1;
        scoreBoard();
    }


    public void scoreBoard()
    {
        enemiesRemaining.text = "Enemies Left: " + allEnemies.ToString() + "/" + maxEnemies;
        // if( allCoins <= 0) { levelUp.SetActive(true); }



        if (allEnemies == 0 || playerCount == 0 )
        {
            endText.text = "Game Over";
        }
		if (allEnemies == 0)
		{
			anim.SetBool("Win",true);
		}
    }
}
