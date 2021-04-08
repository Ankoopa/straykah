using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimScript : MonoBehaviour
{
    public bool isAnimating = true;

    public void animEnded(){
        isAnimating = false;
        Debug.Log("test");
    }
}
