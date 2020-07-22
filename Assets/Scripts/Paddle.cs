using System.Collections;
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
       Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
       paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
       transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (FindObjectOfType<GameSession>().IsAutoPlayEnabled())
        {
            return FindObjectOfType<Ball>().transform.position.x - 1;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
