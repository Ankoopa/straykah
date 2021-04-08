using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTextureArrow : MonoBehaviour
{
    public float speedX = 0.1f;
    public float speedY = 0.1f;
    private float curX;
    private float curY;
    
    void FixedUpdate() {
        curX += Time.deltaTime * speedX;
        curY += Time.deltaTime * speedY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(curX, curY);
    }
}
