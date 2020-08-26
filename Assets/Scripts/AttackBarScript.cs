using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBarScript : MonoBehaviour
{
    private AngelScript ac;
    private float ma = 5f;

    private void Awake() {
        ac = gameObject.GetComponentInParent<AngelScript>();
    }

    private void Update() {
        if (ac.attackCharge > 0)
            transform.localScale = new Vector3(ac.attackCharge / ma * 200, transform.localScale.y, transform.localScale.z);
        else transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
    }
}
