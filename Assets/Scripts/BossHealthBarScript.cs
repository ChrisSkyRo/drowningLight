using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBarScript : MonoBehaviour
{
    private DarkAngelScript health;
    private Transform player;

    private void Awake() {
        health = GameObject.Find("DarkPrince(Clone)").GetComponent<DarkAngelScript>();
        player = GameObject.Find("Angel").GetComponent<Transform>();
    }

    private void Update() {
        if (health != null) {
            if (health.hp > 0)
                transform.localScale = new Vector3(health.hp / health.Mhp * 1000, transform.localScale.y, transform.localScale.z);
            else transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
        }
    }

    private void LateUpdate() {
        transform.position = new Vector3(player.position.x, player.position.y + 5, -1);
    }
}
