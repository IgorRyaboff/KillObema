using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundVolume : MonoBehaviour
{
    public BGMusic bgMusic;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Scrollbar>().onValueChanged.AddListener((float val) => ScrollbarCallback(val));
    }

    // Update is called once per frame
    void ScrollbarCallback(float value)
    {
        bgMusic.SetVolume(value);
    }
}
