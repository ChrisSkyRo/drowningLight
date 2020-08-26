using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilScript : MonoBehaviour
{
    [SerializeField] private Transform fireBall;
    [SerializeField] private Transform deathParticles;
    private Transform target;
    private float hp;
    private float speed = .05f;
    private float timer = 5f;
    private WaveHandler alive;
    private bool waiting;
    public float prestige;
    private AudioManagerScript manager;
    private bool dead;

    private void Awake() {
        dead = false;
        hp = 20;
        prestige = 5f + Random.Range(0f, 1f);
        target = GameObject.Find("Angel").GetComponent<Transform>();
        alive = GameObject.Find("Mechanics").GetComponent<WaveHandler>();
        waiting = false;
        manager = GameObject.Find("SoundManager").GetComponent<AudioManagerScript>();
    }

    private void Update() {
        if (dead) {
            manager.PlaySound("ed");
            alive.enemiesAlive--;
            Instantiate(deathParticles, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(gameObject);
        }
        timer -= Time.deltaTime;
        if(timer < 0) {
            timer = 6f;
            Transform flame = Instantiate(fireBall, transform.position, Quaternion.identity);
            FireballScript fs = flame.GetComponent<FireballScript>();
            Vector2 rot = (transform.position - target.position).normalized;
            Vector2 dir = (target.position - transform.position).normalized;
            fs.Setup(4, rot, dir);
            StartCoroutine(Attack(flame));
        }
    }

    IEnumerator Attack(Transform target) {
        speed = 0;
        yield return new WaitForSeconds(1f);
        manager.PlaySound("et");
        transform.position = target.position;
        Transform flame;
        FireballScript fs;
        Vector2 rot, dir;
        /// Up
        dir = Vector2.up;
        rot = Vector2.down;
        flame = Instantiate(fireBall, transform.position, Quaternion.identity);
        fs = flame.GetComponent<FireballScript>();
        fs.Setup(1, rot, dir);
        /// Right
        dir = Vector2.right;
        rot = Vector2.left;
        flame = Instantiate(fireBall, transform.position, Quaternion.identity);
        fs = flame.GetComponent<FireballScript>();
        fs.Setup(1, rot, dir);
        /// Left
        dir = Vector2.left;
        rot = Vector2.right;
        flame = Instantiate(fireBall, transform.position, Quaternion.identity);
        fs = flame.GetComponent<FireballScript>();
        fs.Setup(1, rot, dir);
        /// Down
        dir = Vector2.down;
        rot = Vector2.up;
        flame = Instantiate(fireBall, transform.position, Quaternion.identity);
        fs = flame.GetComponent<FireballScript>();
        fs.Setup(1, rot, dir);
        /// Diag1
        dir = new Vector2(1, 1);
        rot = new Vector2(-1, -1);
        flame = Instantiate(fireBall, transform.position, Quaternion.identity);
        fs = flame.GetComponent<FireballScript>();
        fs.Setup(1, rot, dir);
        /// Diag2
        dir = new Vector2(1, -1);
        rot = new Vector2(-1, 1);
        flame = Instantiate(fireBall, transform.position, Quaternion.identity);
        fs = flame.GetComponent<FireballScript>();
        fs.Setup(1, rot, dir);
        /// Diag3
        dir = new Vector2(-1, -1);
        rot = new Vector2(1, 1);
        flame = Instantiate(fireBall, transform.position, Quaternion.identity);
        fs = flame.GetComponent<FireballScript>();
        fs.Setup(1, rot, dir);
        /// Diag4
        dir = new Vector2(-1, 1);
        rot = new Vector2(1, -1);
        flame = Instantiate(fireBall, transform.position, Quaternion.identity);
        fs = flame.GetComponent<FireballScript>();
        fs.Setup(1, rot, dir);
        speed = .05f;
    }

    private void FixedUpdate() {
        if (!waiting) {
            if (transform.position.x < target.position.x - 4)
                transform.position += Vector3.right * speed;
            else if (transform.position.x > target.position.x + 4)
                transform.position += Vector3.left * speed;
            if (transform.position.y < target.position.y - 4)
                transform.position += Vector3.up * speed;
            else if (transform.position.y > target.position.y + 4)
                transform.position += Vector3.down * speed;
        }
        waiting = false;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            EyeScript es = collision.GetComponent<EyeScript>();
            if (es != null) {
                if (this.prestige < es.prestige)
                    waiting = true;
            }
            else {
                ImpScript im = collision.GetComponent<ImpScript>();
                if (im != null) {
                    if (this.prestige < im.prestige)
                        waiting = true;
                }
                else {
                    DevilScript ds = collision.GetComponent<DevilScript>();
                    if (ds != null) {
                        if (this.prestige < ds.prestige)
                            waiting = true;
                    }
                    else {
                        DarkAngelScript da = collision.GetComponent<DarkAngelScript>();
                        if (da != null)
                            waiting = true;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "sHalo")
            hp--;
        else if (collision.tag == "uHalo") 
            hp -= 3;
        if (hp <= 0) {
            dead = true;
        }
    }
}
