using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    private Vector2 dir;
    private float speed = .075f;
    private float timer = 5f;
    public int size;
    
    public void Setup(int size, Vector2 rot, Vector2 dir) {
        this.size = size;
        transform.localScale = new Vector3(size, size, 1);
        transform.up = rot;
        this.dir = dir;
    }

    private void Update() {
        timer -= Time.deltaTime;
        if (timer < 0)
            Destroy(gameObject);
    }

    private void FixedUpdate() {
        transform.position += new Vector3(dir.x, dir.y).normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "uHalo" && size < 4)
            Destroy(gameObject);
        if (size < 3 && collision.tag == "Player")
                Destroy(gameObject);
    }
}
