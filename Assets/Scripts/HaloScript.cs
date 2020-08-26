using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloScript : MonoBehaviour
{
    private Vector2 dir;
    private float speed = .2f;
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
        if (collision.tag == "eUltimate")
            Destroy(gameObject);
        if (!ultimate) {
            if (collision.tag == "Enemy" || collision.tag == "eHalo")
                Destroy(gameObject);
            else if (collision.tag == "fireBall") {
                FireballScript fs = collision.gameObject.GetComponent<FireballScript>();
                if(fs.size == 3)
                    Destroy(gameObject);
            }
        }
    }

}
