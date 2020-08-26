using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsXScript : MonoBehaviour
{
    private Transform window;
    private SpriteRenderer sr;
    private Color hover, exit;

    private BoxCollider2D p, i, t1, t2;

    private void Awake() {
        window = GameObject.Find("InstructionsWindow").GetComponent<Transform>();
        sr = gameObject.GetComponentInChildren<SpriteRenderer>();
        hover = new Color(248, 0, 0);
        exit = sr.color;
        p = GameObject.Find("Play").GetComponent<BoxCollider2D>();
        i = GameObject.Find("Instructions").GetComponent<BoxCollider2D>();
        t1 = GameObject.Find("TwitterSky").GetComponent<BoxCollider2D>();
        t2 = GameObject.Find("TwitterOat").GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown() {
        window.position = new Vector3(100, 0, -2);
        p.enabled = true;
        i.enabled = true;
        t1.enabled = true;
        t2.enabled = true;
    }

    private void OnMouseEnter() {
        sr.color = hover;
    }

    private void OnMouseExit() {
        sr.color = exit;
    }
}
