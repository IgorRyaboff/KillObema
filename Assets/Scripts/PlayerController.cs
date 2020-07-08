using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        bool APressed = Input.GetKey("a");
        bool DPressed = Input.GetKey("d");
        if (APressed == DPressed) {}
        else if (APressed && transform.position.x >= -8) transform.Translate(new Vector2(-Time.deltaTime * speed, 0));
        else if (DPressed && transform.position.x <= 8) transform.Translate(new Vector2(Time.deltaTime * speed, 0));

        if (Input.GetKeyDown("space")) Instantiate(bullet, transform.position, transform.rotation);
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
}
