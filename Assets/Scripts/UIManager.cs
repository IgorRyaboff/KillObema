using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointsCounter, bgMusicName;
    public GameObject pauseMenu, pauseBtn;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCounter(100, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCounter(int hp, int bulbs) {
        pointsCounter.text = $"хопэ: {hp}\nлампочки: {bulbs}";
    }

    public void UpdateBGMusicName(string name) {
        bgMusicName.text = "♫ " + name.Replace(".", "");
    }

    public void SetPause(bool value) {
        pauseMenu.SetActive(value);
        pauseBtn.SetActive(!value);
    }
}
