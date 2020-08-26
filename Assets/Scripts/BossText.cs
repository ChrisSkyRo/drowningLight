using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossText : MonoBehaviour
{
    private Transform player;

    private void Awake() {
        player = GameObject.Find("Angel").GetComponent<Transform>();
    }

    private void LateUpdate() {
        transform.position = new Vector3(player.position.x, player.position.y + 4.5f, -1);
    }
}
