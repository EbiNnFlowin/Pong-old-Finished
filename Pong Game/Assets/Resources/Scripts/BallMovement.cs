﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //Float is 7 decimal points. Takes up less space, but less precise
    //Double is 16 decimal points. Takes up more space but more precise
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxExtraSpeed;

    int hitCounter = 0;

    void Start()
    {
        StartCoroutine(this.StartBall());
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);
        this.hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isStartingPlayer1)
        {
            this.MoveBall(new Vector2(-1, 0));
        }
        else
        {
            this.MoveBall(new Vector2(1, 0));
        }
    }
    public void MoveBall (Vector2 dir){
        dir = dir.normalized;
        float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;
    Rigidbody2D rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        //rigidBody2D.velocity = dir*speed*time.deltaTime; 
        rigidBody2D.velocity = dir * speed;
    }

    public void IncreaseHitCounter()
    {
        if(this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
        {
            this.hitCounter++;
        }
    }

    void PositionBall (bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }
    
}
