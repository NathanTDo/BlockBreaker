﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // config params
    [SerializeField] Paddle paddle1 = null;

    // state
    Vector2 paddleToBallDistance;

    // cached component references

    AudioSource myAudioSource;

    // velocity params
    [SerializeField] float horVelocity = 5;
    [SerializeField] float vertVelocity = 5;
    [SerializeField] AudioClip[] ballSounds;

    bool hasStarted = false;




    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = (transform.position - paddle1.transform.position);
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(horVelocity, vertVelocity);

        }
    }


    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];

            myAudioSource.PlayOneShot(clip);

        }
        
    }

}
