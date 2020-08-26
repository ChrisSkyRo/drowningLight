using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BorderTextScript : MonoBehaviour
{
    private Transform player;
    private TextMeshPro text;
    private Color color;

    private void Awake() {
        player = GameObject.Find("Angel").GetComponent<Transform>();
        text = gameObject.GetComponent<TextMeshPro>();
        color = Color.white;
    }

    private void FixedUpdate() {
        if (player.position.x > 28 || player.position.x < -23 || player.position.y > 24 || player.position.y < -21) {
            color.a = 1;
            text.color = color;
        }
        else {
            color.a = 0;
            text.color = color;
        }
    }
}
