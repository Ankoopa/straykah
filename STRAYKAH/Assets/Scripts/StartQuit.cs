using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartQuit : MonoBehaviour
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
    public void Restart(){
        StartCoroutine(WaitClickEndButton());
        SceneManager.LoadScene(0);
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
        Cursor.visible = false;
        yield return new WaitForSeconds(1);
        PanelEnd.SetActive(true);
        PanelEnd.SetActive(false);
        Application.Quit();
    }
}
