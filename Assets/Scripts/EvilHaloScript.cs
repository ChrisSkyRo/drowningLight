using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilHaloScript : MonoBehaviour
{
    private Vector2 dir;
    private float speed = .1f;
    private float timer = 3f;
    private bool ultimate;

    public void Setup(Vector2 direction, bool u) {
        dir = direction;
        ultimate = u;
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
        if (!ultimate) {
            if (collision.tag == "sHalo" || collision.tag == "Player" || collision.tag == "uHalo") 
                Destroy(gameObject);
        }
    }
}
