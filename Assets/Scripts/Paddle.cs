﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Paddle : MonoBehaviour
{
    // configuration parameters

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 14f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
       Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
       paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
       transform.position = paddlePos;
    }
}