using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimation : MonoBehaviour
{
    [SerializeField] private Material original;
    [SerializeField] private Material white;
    private float hitTimer;
    private SpriteRenderer sr;

    private void Awake() {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        hitTimer -= Time.deltaTime;
        if (hitTimer < 0)
            sr.material = original;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "sHalo") {
            hitTimer = .1f;
            sr.material = white;
        }
        else if (collision.tag == "uHalo") {
            hitTimer = .1f;
            sr.material = white;
        }
    }
}
