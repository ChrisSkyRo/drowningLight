using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenInstructionsWindow : MonoBehaviour
{
    private Transform window;
    private TextMeshPro text;
    private MenuManager sound;

    private BoxCollider2D p, i, t1, t2;

    private void Awake() {
        window = GameObject.Find("InstructionsWindow").GetComponent<Transform>();
        text = gameObject.GetComponent<TextMeshPro>();
        sound = GameObject.Find("AudioManager").GetComponent<MenuManager>();
        p = GameObject.Find("Play").GetComponent<BoxCollider2D>();
        i = GameObject.Find("Instructions").GetComponent<BoxCollider2D>();
        t1 = GameObject.Find("TwitterSky").GetComponent<BoxCollider2D>();
        t2 = GameObject.Find("TwitterOat").GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown() {
        window.position = new Vector3(0, 0, -2);
        sound.PlaySound("instr");
        p.enabled = false;
        i.enabled = false;
        t1.enabled = false;
        t2.enabled = false;
    }

    private void OnMouseEnter() {
        text.color = Color.yellow;
    }

    private void OnMouseExit() {
        text.color = Color.white;
    }

}
