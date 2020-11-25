using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gameplayObjects;
    public ButtonPressedDetector goLeftMobile, goRightMobile, fireMobile;
    public int HP = 100, bulbs = 10;
    public float speed = 10;
    public UIManager uiManager;
    public GameObject bullet, player;
    // Start is called before the first frame update
    void Start()
    {
        if (System.DateTime.Now.Month > 11 || System.DateTime.Now.Month < 2) player.transform.Find("newyearhat").gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldGoLeft = Input.GetKey("a") || goLeftMobile.pressed;
        bool shouldGoRight = Input.GetKey("d") || goRightMobile.pressed;
        bool shouldFire = Input.GetKeyDown("space") || fireMobile.pressed;
        fireMobile.pressed = false;
        if (shouldGoLeft == shouldGoRight) {}
        else if (shouldGoLeft && player.transform.position.x >= -8) player.transform.Translate(new Vector2(-Time.deltaTime * speed, 0));
        else if (shouldGoRight && player.transform.position.x <= 8) player.transform.Translate(new Vector2(Time.deltaTime * speed, 0));

        if (shouldFire) Instantiate(bullet, player.transform.position, player.transform.rotation);
    }

    public void AddHP(int value) {
        if (HP + value < 0) HP = 0;
        else if (HP + value > 100) HP = 100;
        else HP += value;
        //Debug.Log($"Updated HP to {HP}");
        uiManager.UpdateCounter(HP, bulbs);
        if (HP == 0) GameOver("Сан Саныч погиб");
    }

    public void AddBulbs(int value) {
        if (bulbs + value < 0) bulbs = 0;
        else bulbs += value;
        //Debug.Log($"Updated bulbs to {bulbs}");
        uiManager.UpdateCounter(HP, bulbs);
        if (bulbs == 0) GameOver("Абэма выкрутил все лампочки");
    }
    public void LeftDown() {
        //
    }
    public void LeftUp() {
        //
    }
    public void RightDown() {
        //
    }
    public void RightUp() {
        //
    }
    public void FireDown() {
        //
    }
    public void FireUp() {
        //
    }

    public void GameOver(string reason) {
        uiManager.GameOver(reason);
        gameplayObjects.SetActive(false);
        player.transform.position = new Vector3(0, -4, 0);
    }
}
