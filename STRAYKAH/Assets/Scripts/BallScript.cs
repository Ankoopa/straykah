using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 throwDirection;
    private float defaultKickForce, kickForce;
    private float directionMultiplier, forceMultiplier;
    public Text powerText;

    public GameObject arrowGuide;
    // Start is called before the first frame update
    void Start()
    {
        powerText = GameObject.FindGameObjectWithTag("powerLevel").GetComponent<Text>();
        rb = gameObject.GetComponent<Rigidbody>();
        throwDirection = new Vector3(150, 50, 150);
        defaultKickForce = 750f;
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetAxis("Mouse X")<0){
            arrowGuide.transform.Rotate(0, -100 * Time.deltaTime, 0);
        }
        if(Input.GetAxis("Mouse X")>0){
            arrowGuide.transform.Rotate(0, 100 * Time.deltaTime, 0);
        }
        if (Input.GetMouseButtonDown(0)){
            float angle = arrowGuide.transform.localRotation.eulerAngles.y;
            angle = (angle > 180) ? angle - 360 : angle; // converts to negative angle if angled to the left

            directionMultiplier = angle / 40;
            throwDirection.x *= directionMultiplier;

            forceMultiplier = (float)int.Parse(powerText.text)/100;
            kickForce = defaultKickForce * forceMultiplier;

            rb.useGravity = true;
            rb.AddForce(throwDirection.normalized * kickForce);
        }

        // if(Input.GetKey("a")){
        //     arrowGuide.transform.Rotate(0, -100 * Time.deltaTime, 0);
        // }
        // if(Input.GetKey("d")){
        //     arrowGuide.transform.Rotate(0, 100 * Time.deltaTime, 0);
        // }
        
        if(arrowGuide.transform.localRotation.eulerAngles.y < 320  && arrowGuide.transform.localRotation.eulerAngles.y > 180){
            arrowGuide.transform.eulerAngles = new Vector3(0, -40, 0);
        }
        else if(arrowGuide.transform.localRotation.eulerAngles.y > 40  && arrowGuide.transform.localRotation.eulerAngles.y < 180){
            arrowGuide.transform.eulerAngles = new Vector3(0, 40, 0);
        }
    }

    public void StartKick(){
        float angle = arrowGuide.transform.localRotation.eulerAngles.y;
        angle = (angle > 180) ? angle - 360 : angle; // converts to negative angle if angled to the left

        directionMultiplier = angle / 40;
        throwDirection.x *= directionMultiplier;

        forceMultiplier = (float)int.Parse(powerText.text)/100;
        kickForce = defaultKickForce * forceMultiplier;

        rb.useGravity = true;
        rb.AddForce(throwDirection.normalized * kickForce);
    }
}