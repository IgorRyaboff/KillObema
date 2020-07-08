using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPModifierObject : MonoBehaviour
{
    public int collisionHP, collisionBulbs, skipBulbs;
    public float speed;
    PlayerController playerController;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead) transform.Translate(new Vector2(0, -Time.deltaTime * speed));
        if (transform.position.y <= -10) {
            Destroy(gameObject);
            playerController.AddBulbs(skipBulbs);
        }
    }

    public void Die() {
        dead = true;
        Destroy(gameObject.GetComponent<Collider2D>());
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator) {
            animator.enabled = true;
            transform.localScale = new Vector3(3, 3, 0);
        }
        else Destroy(gameObject);
    }

    public void DestroyFromAnim() {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log($"HPModifierObject collision with object tagged {col.gameObject.tag}");
        if (col.gameObject.tag == "Player") {
            playerController.AddHP(collisionHP);
            playerController.AddBulbs(collisionBulbs);
            Die();
        }
    }
}
