using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, Time.deltaTime * speed));
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log($"Bullet collision with object tagged {col.gameObject.tag}");
        if (col.gameObject.tag == "HPModifierObject") {
            col.gameObject.GetComponent<HPModifierObject>().Die();
            Destroy(gameObject);
        }
    }
}
