using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkAngelScript : MonoBehaviour
{
    [SerializeField] private Transform halo;
    [SerializeField] private Transform ultimateHalo;
    [SerializeField] private Transform teleportParticles;
    [SerializeField] private Transform eye;
    [SerializeField] private AudioClip winMusic;
    private Transform target;
    private Vector3[] points = new[] {
        new Vector3(0, 5, 0),
        new Vector3(5, 0, 0),
        new Vector3(0, -5, 0),
        new Vector3(-5, 0, 0),
        new Vector3(-3, 3, 0),
        new Vector3(3, 3, 0),
        new Vector3(3, -3, 0),
        new Vector3(-3, -3, 0),
    };
    private Vector3[] points3 = new[] {
        new Vector3(0, 4, 0),
        new Vector3(4, 0, 0),
        new Vector3(0, -4, 0),
        new Vector3(-4, 0, 0),
    };
    public float prestige;
    public float hp, Mhp;
    private States attack;
    private float stateTimer = 30f, attackTimer = 1f;
    private float speed;
    private int point, point3;
    private AudioManagerScript manager;
    private bool dead;
    private enum States {
        Attack1,
        Attack2,
        Attack3,
    }
    public Animator victory;
    private void Awake() {
        dead = false;
        prestige = 100;
        point = 0;
        point3 = 0;
        speed = .1f;
        Mhp = 100;
        hp = 100;
        attack = States.Attack1;
        target = GameObject.Find("Angel").GetComponent<Transform>();
        manager = GameObject.Find("SoundManager").GetComponent<AudioManagerScript>();
        victory = GameObject.Find("Victory").GetComponentInChildren<Animator>();
    }

    private void Update() {
        if (dead) {
            AudioSource source = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
            source.clip = winMusic;
            source.volume = .5f;
            source.Play();
            victory.SetTrigger("victory");
            Instantiate(teleportParticles, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(gameObject);
        }
        stateTimer -= Time.deltaTime;
        attackTimer -= Time.deltaTime;
        if (attackTimer < 0) {
            attackTimer = 1f;
            if (attack == States.Attack2) {
                Transform multiHalo;
                EvilHaloScript hs;
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
                multiHalo = Instantiate(halo, transform.position, Quaternion.identity);
                hs = multiHalo.GetComponent<EvilHaloScript>();
                hs.Setup(dir, false);
                pos = new Vector2(radius * Mathf.Cos(angle + spread) + transform.position.x, radius * Mathf.Sin(angle + spread) + transform.position.y);
                dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
                rot = new Vector2(transform.position.x - pos.x, transform.position.y - pos.y);
                multiHalo = Instantiate(halo, transform.position, Quaternion.identity);
                hs = multiHalo.GetComponent<EvilHaloScript>();
                hs.Setup(dir, false);
            }
            else if (attack == States.Attack1) {
                attackTimer = .5f;
                Transform singleHalo = Instantiate(halo, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
                Vector2 pos = target.position;
                Vector2 dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
                EvilHaloScript hs = singleHalo.GetComponent<EvilHaloScript>();
                hs.Setup(dir, false);
            }
            else {
                manager.PlaySound("et");
                transform.position = target.position + points3[point3];
                Instantiate(teleportParticles, transform.position, Quaternion.identity);
                point3 = (point3 + 1) % 4;
                Transform multiHalo;
                EvilHaloScript hs;
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
                multiHalo = Instantiate(ultimateHalo, transform.position, Quaternion.identity);
                hs = multiHalo.GetComponent<EvilHaloScript>();
                hs.Setup(dir, true);
                StartCoroutine(SpawnEye(multiHalo));
                pos = new Vector2(radius * Mathf.Cos(angle + spread) + transform.position.x, radius * Mathf.Sin(angle + spread) + transform.position.y);
                dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
                rot = new Vector2(transform.position.x - pos.x, transform.position.y - pos.y);
                multiHalo = Instantiate(ultimateHalo, transform.position, Quaternion.identity);
                hs = multiHalo.GetComponent<EvilHaloScript>();
                hs.Setup(dir, true);
                StartCoroutine(SpawnEye(multiHalo));
                attack = States.Attack1;
            }
        }
        if (stateTimer < 0) {
            stateTimer = 30f;
            if (attack == States.Attack1)
                attack = States.Attack2;
            else if (attack == States.Attack2)
                attack = States.Attack3;
            else attack = States.Attack1;
        }
    }

    IEnumerator SpawnEye(Transform pos) {
        yield return new WaitForSeconds(1);
        Transform leye = Instantiate(eye, new Vector3(pos.position.x, pos.position.y, 0), Quaternion.identity);
        EyeScript es = leye.GetComponent<EyeScript>();
        es.Setup(3);
    }

    private void FixedUpdate() {
        if (attack == States.Attack2) {
            if (Vector2.Distance(transform.position, target.position) < 8 && Vector2.Distance(transform.position, target.position) > 2) {
                transform.RotateAround(target.position, Vector3.forward, 1f);
                transform.up = Vector3.up;
            }
            else {
                manager.PlaySound("et");
                transform.position = new Vector3(target.position.x, target.position.y+4, 0);
                Instantiate(teleportParticles, transform.position, Quaternion.identity);
            }
        }
        else if (attack == States.Attack1) {
            Vector3 dir = ((target.position + points[point]) - transform.position).normalized;
            transform.position += dir * speed;
            if (Vector3.Distance(transform.position, (target.position + points[point])) < .075f)
                point = (point + 1) % 8;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "sHalo")
            hp--;
        else if (collision.tag == "uHalo")
            hp -= 6;
        if (hp <= 0) {
            dead = true;
            AngelScript a = target.GetComponent<AngelScript>();
            a.win = true;
        }
    }
}
