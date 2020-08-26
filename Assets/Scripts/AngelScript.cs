using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngelScript : MonoBehaviour
{
    [SerializeField] private Transform teleportParticles;
    [SerializeField] private Transform halo;
    [SerializeField] private Transform ultimateHalo;
    public Animator death;
    private float speed = .075f;
    private bool dead;
    public bool win;
    public float hp, Mhp;
    public float attackCharge;
    public float teleportTimer;
    private AudioManagerScript manager;
    private Animator facing;

    private void Awake() {
        dead = false;
        win = false;
        hp = 20;
        Mhp = 20;
        attackCharge = 5f;
        teleportTimer = 0;
        manager = GameObject.Find("SoundManager").GetComponent<AudioManagerScript>();
        facing = GameObject.Find("AngelGraphic").GetComponent<Animator>();
    }

    private void Update() {
        teleportTimer -= Time.deltaTime;
        attackCharge += Time.deltaTime*1.5f;
        Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mp.y > transform.position.y+.75f)
            facing.SetBool("front", false);
        else facing.SetBool("front", true);
        if (attackCharge > 5)
            attackCharge = 5;
        if(Input.GetMouseButtonDown(0) && attackCharge > 0 && !dead && !win) {
            if(attackCharge == 5) {
                manager.PlaySound("ps");
                attackCharge -= 5;
                Transform singleHalo = Instantiate(ultimateHalo, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
                HaloScript hs = singleHalo.GetComponent<HaloScript>();
                hs.Setup(dir, true);
            }
            else if(attackCharge > 3) {
                manager.PlaySound("ps");
                attackCharge -= 3;
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
                float spread = 15f * Mathf.Deg2Rad;
                float radius = Vector2.Distance(pos, transform.position);
                float sign = (dir.y >= 0) ? 1 : -1;
                float offset = (sign >= 0) ? 0 : 360;
                float angle = (Vector2.Angle(Vector2.right, dir) * sign + offset) * Mathf.Deg2Rad;
                Transform multiHalo = Instantiate(halo, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
                HaloScript hs = multiHalo.GetComponent<HaloScript>();
                hs.Setup(dir, false);
                pos = new Vector2(radius * Mathf.Cos(angle - spread) + transform.position.x, radius * Mathf.Sin(angle - spread) + transform.position.y);
                dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
                multiHalo = Instantiate(halo, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
                hs = multiHalo.GetComponent<HaloScript>();
                hs.Setup(dir, false);
                pos = new Vector2(radius * Mathf.Cos(angle + spread) + transform.position.x, radius * Mathf.Sin(angle + spread) + transform.position.y);
                dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
                multiHalo = Instantiate(halo, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
                hs = multiHalo.GetComponent<HaloScript>();
                hs.Setup(dir, false);
            }
            else if (attackCharge > 1) {
                manager.PlaySound("ps");
                attackCharge--;
                Transform singleHalo = Instantiate(halo, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
                HaloScript hs = singleHalo.GetComponent<HaloScript>();
                hs.Setup(dir, false);
            }
        }
        if (!dead) {
            if (transform.position.x > 30 || transform.position.x < -25 || transform.position.y > 26 || transform.position.y < -23) {
                manager.PlaySound("pd");
                dead = true;
                StartCoroutine(DeathAnimation());
            }
        }
        if (win) {
            speed = 0;
            AudioSource source = GameObject.Find("SoundManager").GetComponent<AudioSource>();
            source.mute = true;
        }
    }

    private void FixedUpdate() {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.J)) && transform.position.x > -23)
            transform.position += Vector3.left * speed;
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.L)) && transform.position.x < 28)
            transform.position += Vector3.right * speed;
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.I)) && transform.position.y < 24)
            transform.position += Vector3.up * speed;
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.K)) && transform.position.y > -21)
            transform.position += Vector3.down * speed;
        if (Input.GetMouseButtonDown(1) && teleportTimer < 0 && !dead && !win) {
            manager.PlaySound("pt");
            hp += 3;
            if (hp > Mhp)
                hp = Mhp;
            teleportTimer = 5f;
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            Instantiate(teleportParticles, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!dead) {
            if (collision.tag == "fireBall") {
                FireballScript fs = collision.GetComponent<FireballScript>();
                hp -= fs.size;
                if (!dead)
                    manager.PlaySound("ph");
            }
            else if (collision.tag == "eHalo") {
                hp -= 2;
                if (!dead)
                    manager.PlaySound("ph");
            }
            else if (collision.tag == "eUltimate") {
                hp -= 6;
                if (!dead)
                    manager.PlaySound("ph");
            }
            if (hp <= 0) {
                manager.PlaySound("pd");
                StartCoroutine(DeathAnimation());
            }
        }
    }

    IEnumerator DeathAnimation() {
        AudioSource source = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        source.mute = true;
        speed = 0;
        dead = true;
        death.SetTrigger("StartDeath");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

}
