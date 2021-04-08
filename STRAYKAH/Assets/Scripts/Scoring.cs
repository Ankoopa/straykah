using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Scoring : MonoBehaviour
{
    public int score = 0;
    public Text text;
    private float moveLevel = 5;
    public GameObject Ball1;
    public GameObject Ball2;
    public GameObject Ball3;
    public GameObject Ball4;
    
    public GameObject Sphere;

    public GameObject Arrow;

    public Transform Waypoint1;
    public Transform Waypoint2;
    public Transform Waypoint3;
    public Transform Waypoint4;
    public Transform BallWaypoint;

    public GameObject BonusShot;
    public GameObject Character;
    public GameObject BallObject;

    public GameObject FadeEndUI;

    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponent<Text>();
        BonusShot.SetActive(false);
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider collision) {
        if(collision.transform.name == "Ball") {
        
            score = score + 25;
            moveLevel -= 1;
            
            if (moveLevel == 5){
                Ball1.SetActive(false);
                Ball2.SetActive(false);
                Ball3.SetActive(false);
                Ball4.SetActive(false);
            }
            else if (moveLevel == 4){
                Ball4.SetActive(true);

                Character.transform.position = Waypoint1.position;
                Character.transform.rotation = Waypoint1.rotation;
                BallObject.transform.position = BallWaypoint.position;
                BallObject.transform.rotation = BallWaypoint.rotation;
            }
            else if (moveLevel == 3){
                Ball3.SetActive(true);

                Character.transform.position = Waypoint2.position;
                Character.transform.rotation = Waypoint2.rotation;
                BallObject.transform.position = BallWaypoint.position;
                BallObject.transform.rotation = BallWaypoint.rotation;
            }
            else if (moveLevel == 2){
                Ball2.SetActive(true);

                Character.transform.position = Waypoint3.position;
                Character.transform.rotation = Waypoint3.rotation;
                BallObject.transform.position = BallWaypoint.position;
                BallObject.transform.rotation = BallWaypoint.rotation;
            }
            else if (moveLevel == 1){
                Ball1.SetActive(true);
                BonusShot.SetActive(true);

                Character.transform.position = Waypoint4.position;
                Character.transform.rotation = Waypoint4.rotation;
                BallObject.transform.position = BallWaypoint.position;
                BallObject.transform.rotation = BallWaypoint.rotation;
            }
            else if (moveLevel == 0){
                StartCoroutine(MoveLevel());

            }
            text.text = score.ToString();
        }
    }
    IEnumerator MoveLevel (){
        FadeEndUI.SetActive(true);
        BonusShot.SetActive(false);
   
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }
}
