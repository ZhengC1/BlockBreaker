using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // config params
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        // static paddle position
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(xValue, xMin, xMax);
        transform.position = paddlePos;
    }
}
