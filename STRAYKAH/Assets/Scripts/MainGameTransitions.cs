using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameTransitions : MonoBehaviour
{
    // Start
    public GameObject PanelStart;
    public GameObject PanelEnd;
    void Start() {
        PanelStart.SetActive(true);
        StartCoroutine(WaitClickStart());
    }
    public void StartGame(){
        StartCoroutine(WaitClickStartButton());
    }
    public void QuitGame(){
        StartCoroutine(WaitClickEndButton());
    }
    // Enumarators
    IEnumerator WaitClickStart(){
        yield return new WaitForSeconds(1);
        PanelStart.SetActive(false);
    }
    IEnumerator WaitClickStartButton(){
        yield return new WaitForSeconds(2);
        PanelStart.SetActive(false);
        PanelEnd.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
    IEnumerator WaitClickEndButton(){
        yield return new WaitForSeconds(2);
        PanelEnd.SetActive(true);
        PanelEnd.SetActive(false);
        Application.Quit();
    }


    //public void Restart(){
    //     StartCoroutine(LoadLevel());
    //     SceneManager.LoadScene(0);
    // }

}
