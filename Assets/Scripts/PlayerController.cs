using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ButtonPressedDetector goLeftMobile, goRightMobile, fireMobile;
    public int HP = 100, bulbs = 10;
    public float speed = 10;
    public UIManager uiManager;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        if (System.DateTime.Now.Month > 11 || System.DateTime.Now.Month < 2) transform.Find("newyearhat").gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldGoLeft = Input.GetKey("a") || goLeftMobile.pressed;
        bool shouldGoRight = Input.GetKey("d") || goRightMobile.pressed;
        bool shouldFire = Input.GetKeyDown("space") || fireMobile.pressed;
        fireMobile.pressed = false;
        if (shouldGoLeft == shouldGoRight) {}
        else if (shouldGoLeft && transform.position.x >= -8) transform.Translate(new Vector2(-Time.deltaTime * speed, 0));
        else if (shouldGoRight && transform.position.x <= 8) transform.Translate(new Vector2(Time.deltaTime * speed, 0));

        if (shouldFire) Instantiate(bullet, transform.position, transform.rotation);
    }

    public void AddHP(int value) {
        if (HP + value < 0) HP = 0;
        else HP += value;
        //Debug.Log($"Updated HP to {HP}");
        uiManager.UpdateCounter(HP, bulbs);
    }

    public void AddBulbs(int value) {
        if (bulbs + value < 0) bulbs = 0;
        else bulbs += value;
        //Debug.Log($"Updated bulbs to {bulbs}");
        uiManager.UpdateCounter(HP, bulbs);
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
}
