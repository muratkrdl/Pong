using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigid;
    [SerializeField] float ballMoveSpeed = 5f;
    [SerializeField] int ballStartValueMax = 50;
    [SerializeField] int ballStartValueMin = 25;

    [SerializeField] float ballStartDelay = 1f;

    GameManager gameManager;
    
    void Awake() 
    {
        gameManager = FindObjectOfType<GameManager>();    
    }

    int randomIndex;

    void Start() 
    {
        Invoke("StartBallMovement", ballStartDelay);
    }

    void StartBallMovement()
    {
        float startHorizontal = Random.Range(ballStartValueMin, ballStartValueMax);

        randomIndex = Random.Range(0,2);
        if(randomIndex == 1) { startHorizontal *= -1; }
        else { startHorizontal *= 1; }

        float startVertical = Random.Range(ballStartValueMin, ballStartValueMax);

        randomIndex = Random.Range(0,2);
        if(randomIndex == 1) { startVertical *= -1; }
        else { startVertical *= 1; }

        myRigid.velocity = (new Vector2(startHorizontal / 100, startVertical / 100) * ballMoveSpeed);

        Debug.Log(myRigid.velocity);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("LeftDeath"))
        {
            DoAfterCollisionDeath();
            gameManager.IncreaseScoreRight();
        }
        else if(other.gameObject.CompareTag("RightDeath"))
        {
            DoAfterCollisionDeath();
            gameManager.IncreaseScoreLeft();
        }    
    }

    void DoAfterCollisionDeath()
    {
        transform.position = new Vector2(0, 0);
        myRigid.velocity = new Vector2(0, 0);

        Invoke("StartBallMovement", ballStartDelay);
    }

}
