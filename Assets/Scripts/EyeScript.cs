using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    [SerializeField] private Transform fireBall;
    [SerializeField] private Transform deathParticles;
    private Transform target;
    private float hp;
    private float speed = .0375f;
    private float timer;
    private int size;
    private WaveHandler alive;
    private bool waiting;
    public float prestige;
    private AudioManagerScript manager;
    private bool dead;

    private void Awake() {
        dead = false;
        target = GameObject.Find("Angel").GetComponent<Transform>();
        alive = GameObject.Find("Mechanics").GetComponent<WaveHandler>();
    }

    public void Setup(int size) {
        this.size = size;
        hp = size*2;
        transform.localScale = new Vector3(size, size, 1);
        prestige = size + Random.Range(0f, 1f);
        timer = size;
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
            timer = size;
            Transform flame = Instantiate(fireBall, transform.position, Quaternion.identity);
            FireballScript fs = flame.GetComponent<FireballScript>();
            Vector2 rot = (transform.position - target.position).normalized;
            Vector2 dir = (target.position - transform.position).normalized;
            fs.Setup(size, rot, dir);
        }
    }

    private void FixedUpdate() {
        if (!waiting) {
            if (transform.position.x < target.position.x - 3)
                transform.position += Vector3.right * speed;
            else if (transform.position.x > target.position.x + 3)
                transform.position += Vector3.left * speed;
            if (transform.position.y < target.position.y - 3)
                transform.position += Vector3.up * speed;
            else if (transform.position.y > target.position.y + 3)
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
                    if(ds != null) {
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
        if (collision.tag == "sHalo") {
            hp--;
        }
        else if (collision.tag == "uHalo") {
            hp -= 3;
        }
        if (hp <= 0) {
            dead = true;
        }
    }

}
