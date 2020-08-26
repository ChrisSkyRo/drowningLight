using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveTextScript : MonoBehaviour
{

    private float timer;
    private Color color;
    private TextMeshPro text;
    private Transform player;

    private void Awake() {
        text = gameObject.GetComponent<TextMeshPro>();
        color = Color.white;
        player = GameObject.Find("Angel").GetComponent<Transform>();
    }

    public void Setup(int wave) {
        timer = .1f;
        if (wave == 1)
            text.text = "I. Limbo";
        else if (wave == 2)
            text.text = "II. Lust";
        else if (wave == 3)
            text.text = "III. Glutonny";
        else if (wave == 4)
            text.text = "IV. Greed";
        else if (wave == 5)
            text.text = "V. Wrath";
        else if (wave == 6)
            text.text = "VI. Heresy";
        else if (wave == 7)
            text.text = "VII. Violence";
        else if (wave == 8)
            text.text = "VIII. Fraud";
        else text.text = "IX. Treachery";
    }

    private void Update() {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer = .1f;
            color.a -= 0.02f;
            text.color = color;
            if (color.a < 0)
                Destroy(gameObject);
        }
    }

    private void LateUpdate() {
        transform.position = player.position + Vector3.up * 3.5f;
    }
}
