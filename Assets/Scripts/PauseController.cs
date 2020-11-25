using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject gameplayObjects;
    public UIManager uiMan;
    bool paused = false;

    public void Start() {
    }

    public void SetPause() {
        paused = !paused;
        gameplayObjects.SetActive(!paused);
        uiMan.SetPause(paused);
        Debug.Log("Pause state set to " + paused);
    }
}
