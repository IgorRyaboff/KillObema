using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointsCounter, bgMusicName;
    public GameObject pauseBtn, gameOverScreen, gameOverReason, goToMainButton, mainMenu, startButton, indicators, rightControls, gameplayObjects, changeMusicBtn;
    public BGMusic bgMusic;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCounter(100, 10);
        GoToMainMenu();
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
        //pauseBtn.SetActive(!value);
    }

    public void GameOver(string reason) {
        pauseBtn.SetActive(false);
        changeMusicBtn.SetActive(false);
        gameOverScreen.SetActive(false);
        mainMenu.SetActive(false);
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("HPModifierObject"))
        {
            Destroy(obj);
        }

        gameOverScreen.SetActive(true);

        gameOverReason.GetComponent<Text>().text = reason;
        
        bgMusic.Reset(0);
    }

    public void GoToMainMenu(bool resetMusic = true) {
        pauseBtn.SetActive(false);
        changeMusicBtn.SetActive(false);
        gameOverScreen.SetActive(false);

        mainMenu.SetActive(true);

        if (resetMusic) bgMusic.Reset(0);
    }

    public void StartGame() {
        mainMenu.SetActive(false);
        gameOverScreen.SetActive(false);

        pauseBtn.SetActive(true);
        gameplayObjects.SetActive(true);
        changeMusicBtn.SetActive(true);

        bgMusic.Reset(1);

        player.HP = 100;
        player.bulbs = 10;
        UpdateCounter(100, 10);
    }
}
