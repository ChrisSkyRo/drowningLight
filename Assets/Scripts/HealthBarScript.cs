using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    private AngelScript health;

    private void Awake() {
        health = gameObject.GetComponentInParent<AngelScript>();
    }

    private void Update() {
        if (health.hp > 0)
            transform.localScale = new Vector3(health.hp / health.Mhp * 500, transform.localScale.y, transform.localScale.z);
        else transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
    }
}
