using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBarScript : MonoBehaviour
{
    private AngelScript tt;
    private float mt = 5f;

    private void Awake() {
        tt = gameObject.GetComponentInParent<AngelScript>();
    }

    private void Update() {
        if (tt.teleportTimer > 0)
            transform.localScale = new Vector3(tt.teleportTimer / mt * 200, transform.localScale.y, transform.localScale.z);
        else transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
    }
}
