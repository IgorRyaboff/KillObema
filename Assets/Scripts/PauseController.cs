using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject gameplayObjects;
    public UIManager uiMan;

    public void SetPause(bool value) {
        gameplayObjects.SetActive(!value);
        uiMan.SetPause(value);
    }
}
