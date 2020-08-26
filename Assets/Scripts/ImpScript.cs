using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpScript : MonoBehaviour {
    [SerializeField] private Transform fireBall;
    [SerializeField] private Transform deathParticles;
    private Vector3[] points = new[] {
        new Vector3(0, -1, 1),
        new Vector3(-0.59f, 0.8f, 1),
        new Vector3(0.95f, -0.3f, 1),
        new Vector3(-0.95f, -0.3f, 1),
        new Vector3(0.59f, 0.8f, 1),
    };
    private float distance = 5f;
    private int point;
    private Transform target;
    private float hp;
    private float speed = .1f;
    private float timer = 2f;
    private WaveHandler alive;
    private bool waiting;
    public float prestige;
    private AudioManagerScript manager;
    private bool dead;

    private void Awake() {
        dead = false;
        point = 0;
        hp = 10;
        prestige = 4f + Random.Range(0f, 1f);
        waiting = false;
        target = GameObject.Find("Angel").GetComponent<Transform>();
        alive = GameObject.Find("Mechanics").GetComponent<WaveHandler>();
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
            timer = 2f;
            Transform flame;
            FireballScript fs;
            Vector2 dir, rot, pos;
            dir = (target.position - transform.position).normalized;
            float spread = 5f * Mathf.Deg2Rad;
            float radius = Vector2.Distance(target.position, transform.position);
            float sign = (dir.y >= 0) ? 1 : -1;
            float offset = (sign >= 0) ? 0 : 360;
            float angle = (Vector2.Angle(Vector2.right, dir) * sign + offset) * Mathf.Deg2Rad;
            pos = new Vector2(radius * Mathf.Cos(angle - spread) + transform.position.x, radius * Mathf.Sin(angle - spread) + transform.position.y);
            dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
            rot = new Vector2(transform.position.x - pos.x, transform.position.y - pos.y);
            flame = Instantiate(fireBall, transform.position, Quaternion.identity);
            fs = flame.GetComponent<FireballScript>();
            fs.Setup(2, rot, dir);
            pos = new Vector2(radius * Mathf.Cos(angle + spread) + transform.position.x, radius * Mathf.Sin(angle + spread) + transform.position.y);
            dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
            rot = new Vector2(transform.position.x - pos.x, transform.position.y - pos.y);
            flame = Instantiate(fireBall, transform.position, Quaternion.identity);
            fs = flame.GetComponent<FireballScript>();
            fs.Setup(2, rot, dir);
        }
    }

    private void FixedUpdate() {
        if (!waiting) {
            Vector2 dir = (new Vector2(target.position.x + points[point].x*distance, target.position.y + points[point].y*distance) - new Vector2(transform.position.x, transform.position.y)).normalized;
            transform.position += new Vector3(dir.x, dir.y, 0) * speed;
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.position.x + points[point].x*distance, target.position.y + points[point].y*distance)) < speed)
                point = (point + 1) % 5;
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
