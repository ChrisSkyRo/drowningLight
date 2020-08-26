using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnHandler : MonoBehaviour
{
    private Link l;
    private Link1 l1;
    private SpriteRenderer sr;
    public int Link;

    private void Awake() {
        l = gameObject.GetComponent<Link>();
        l1 = gameObject.GetComponent<Link1>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown() {
        if (Link == 0)
            l.OpenTwitter();
        else l1.OpenTwitter();
    }

    private void OnMouseEnter() {
        sr.color = Color.blue;
    }

    private void OnMouseExit() {
        sr.color = Color.white;
    }

}
