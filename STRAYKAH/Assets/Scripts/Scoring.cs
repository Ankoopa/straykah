using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Scoring : MonoBehaviour
{
    public int score = 0;
    public Text text;
    private int moveLevel = 5;
    public GameObject[] balls;
    
    public GameObject Sphere;

    public GameObject Arrow;

    public Transform[] waypoints;
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

            switch(moveLevel){
                case 0:
                    StartCoroutine(MoveLevel());
                    break;
                case 5:
                    foreach(GameObject ball in balls) ball.SetActive(false);
                    break;
                default:
                    balls[moveLevel-1].SetActive(true);
                    Character.transform.position = waypoints[moveLevel-1].position;
                    Character.transform.rotation = waypoints[moveLevel-1].rotation;
                    BallObject.transform.position = BallWaypoint.position;
                    BallObject.transform.rotation = BallWaypoint.rotation;
                    break;

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
